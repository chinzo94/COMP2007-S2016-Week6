using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//required using statements to connect to EF DB
using COMP2007_S2016_Week6.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace COMP2007_S2016_Week6
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading the page for first time, populate the student grid
            if (!IsPostBack)
            {
                //default sort column and direction
                Session["SortColumn"] = "StudentID";
                Session["SortDirection"] = "ASC";

                //Get Student Data
                this.GetStudents();
            }
        }

        /**
         *<summary>
         * This method gets the student data from the DB
         * </summary>summary>
         * 
         * @Method GetStudents 
         **/
        protected void GetStudents()
        {
            //connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                //query the Students Table using EF and LINQ
                var Students = (from allStudents in db.Students
                                select allStudents);

                //bind the result to the GridView
                StudentsGridView.DataSource = Students.AsQueryable().OrderBy(SortString).ToList();
                StudentsGridView.DataBind();
            }

        }

        /// <summary>
        /// This event handler deletes a student from the db using EF
        /// </summary>
        /// 
        /// <param name="sender">{object} sender</param>
        /// <param name="e">{GridViewDeleteEventArgs} e</param>
        /// 
        /// @method StudentsGridView_RowDeleting
        protected void StudentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked
            int selectedRow = e.RowIndex;

            //get the selected StudentID using the Grid's DataKey collection
            int StudentID = Convert.ToInt32(StudentsGridView.DataKeys[selectedRow].Values["StudentID"]);

            try
            {
                //use EF to find the selected student in the DB and remove it
                using (DefaultConnection db = new DefaultConnection())
                {
                    //create object of student class and store the  query string inside of it
                    Student deletedStudent = (from studentRecords in db.Students
                                              where studentRecords.StudentID == StudentID
                                              select studentRecords).FirstOrDefault();

                    //remove the selected student from the db
                    db.Students.Remove(deletedStudent);

                    //save changes to db
                    db.SaveChanges();

                    //refresh the grid
                    this.GetStudents();
                }
            }
            catch (Exception err)
            {
                //error message

            }
        }

        /// <summary>
        /// This event handler allows pagination to occur for the Students page
        /// </summary>
        /// <param name="sender">{object}</param>
        /// <param name="e">{GridViewPageEventArgs}</param>
        protected void StudentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page number
            StudentsGridView.PageIndex = e.NewPageIndex;

            //refresh the grid
            this.GetStudents();
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the new page size
            StudentsGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            //refresh the grid
            this.GetStudents();
        }

        protected void StudentsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            //refresh the grid
            this.GetStudents();

            //toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        protected void StudentsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                //if header row has been clicked
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    LinkButton linkButton = new LinkButton();

                    for (int index = 0; index < StudentsGridView.Columns.Count - 1; index++)
                    {
                        if (StudentsGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkButton.Text = "<i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkButton.Text = "<i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkButton);
                        }
                    }
                }
            }
        }
    }
}