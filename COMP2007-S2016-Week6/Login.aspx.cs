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

namespace COMP2007_S2016_Week6
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //create new userStore and userManager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //search for and create a new user object
            var user = userManager.Find(UserNameTextBox.Text, PasswordTextBox.Text);

            //if match is found
            if(user != null)
            {
                //authenticate and login our new user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //sign in
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                //redirect to main menu
                Response.Redirect("~/Contoso/MainMenu.aspx");
            }
            else
            {
                //display error in the AlertFlash div
                StatusLabel.Text = "Invalid Username or Password";
                AlertFlash.Visible = true;
            }
        }
    }
}