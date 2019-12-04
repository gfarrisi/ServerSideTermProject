using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class UserOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {

            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
            }
        }

        protected void ItemBoundConfig(object sender, RepeaterItemEventArgs args)
        {
            List<string> values = new List<string>();


            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
            }
        }


        protected void lbAccountSettings_Click(object sender, EventArgs e)
        {

        }

        protected void lbPaymentInfo_Click(object sender, EventArgs e)
        {

        }

        protected void lbCurrentOrders_Click(object sender, EventArgs e)
        {

        }
    }
}