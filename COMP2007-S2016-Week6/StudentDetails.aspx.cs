using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//required using statements to connect to EF DB
using COMP2007_S2016_Week6.Models;
using System.Web.ModelBinding;


namespace COMP2007_S2016_Week6
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetStudent();
            }
        }

        protected void GetStudent()
        {
            //populate the form with existing data from the database
            int StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            using (DefaultConnection db = new DefaultConnection())
            {
                //populate a student object instance with the StudentID from the URL Parameter
                Student updatedStudent = (from student in db.Students
                                          where student.StudentID == StudentID
                                          select student).FirstOrDefault();

                //map the student properties to the form controls
                if (updatedStudent != null)
                {
                    LastNameTextBox.Text = updatedStudent.LastName;
                    FirstNameTextBox.Text = updatedStudent.FirstMidName;
                    EnrollmentDateTextBox.Text = updatedStudent.EnrollmentDate.ToString("yyyy-MM-dd");
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //redirect back to students page
            Response.Redirect("~/Students.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                //use student model to create a new student object and save a new record
                Student newStudent = new Student();

                int StudentID = 0;

                //url contains a student id
                if (Request.QueryString.Count > 0)
                {
                    //get id from url
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    //get the current student from EF DB
                    newStudent = (from student in db.Students
                                  where student.StudentID == StudentID
                                  select student).FirstOrDefault();
                }

                //add data to the newStudent record
                newStudent.LastName = LastNameTextBox.Text.ToString();
                newStudent.FirstMidName = FirstNameTextBox.Text.ToString();
                newStudent.EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextBox.Text);

                //use LINQ and ADO.NET to add / insert new student into the database
                if (StudentID == 0)
                {
                    db.Students.Add(newStudent);
                }

                //save changes - also updates and inserts
                db.SaveChanges();

                //redirect back to updated students page
                Response.Redirect("~/Students.aspx");
            }
        }
    }
}