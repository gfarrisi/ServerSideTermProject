using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class RestaurantRepView : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {

            //remove cookies
            //HttpCookie cookie = Request.Cookies["VisitorSessionID"];

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
            Session.Clear();
            Session.Abandon();

            Response.Redirect("Default.aspx");
        }
    }
}