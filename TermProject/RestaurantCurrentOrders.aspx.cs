using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class RestaurantCurrentOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbMenuManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("RestaurantLanding.aspx");
        }

        protected void lbAccountSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("RestaurantAccountSettings.aspx");
        }

        protected void lbPaymentInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("RestaurantPaymentInfo.aspx");
        }

        protected void lbCurrentOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("RestaurantCurrentOrders.aspx");
        }
    }
}