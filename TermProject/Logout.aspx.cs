using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["VisitorSessionID"];

            if (cookie != null)
            {
                Response.Cookies.Remove("VisitorSessionID");
                cookie.Value = null;
                cookie.Values["Email"] = null;
                cookie.Expires = DateTime.Now.AddDays(-30);
                Response.SetCookie(cookie);
            }
            //clear session
            Session.Remove("Email");
            Session.Remove("AccountType");
            Session.Remove("RestaurantID");

            Response.Redirect("Default.aspx");
        }
    }
}