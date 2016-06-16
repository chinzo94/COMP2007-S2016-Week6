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
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //store session info and authentication mentods in the authenticationManager object
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            //perform signout
            authenticationManager.SignOut();

            Response.Redirect("~/Login.aspx");
        }
    }
}