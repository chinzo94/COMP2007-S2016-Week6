using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required for identity and owin security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

/**
 * @author: Chad Ostler
 * @date: June 2, 2016
 * @Version: 0.0.2 - updated active page method to include new links
 * 
 * */

namespace COMP2007_S2016_Week6
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //check if a user is logged in
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    //show logged in content
                    ContosoPlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = false;
                }
                else
                {
                    //show logged out content
                    ContosoPlaceHolder.Visible = false;
                    PublicPlaceHolder.Visible = true;
                }

                SetActivePage();
            }
            
        }

        /**
         * Adds a css class of "active" to list items relating to the current page
         * 
         * @Private
         * @Method SetActivePage
         * 
         * */
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Students":
                    students.Attributes.Add("class", "active");
                    break;
                case "Courses":
                    courses.Attributes.Add("class", "active");
                    break;
                case "Departments":
                    departments.Attributes.Add("class", "active");
                    break;
                case "Contoso Menu":
                    menu.Attributes.Add("class", "active");
                    break;
                case "Login":
                    login.Attributes.Add("class", "active");
                    break;
                case "Register":
                    register.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}