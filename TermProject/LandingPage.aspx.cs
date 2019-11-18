using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TermProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 5; i++)
            {
                RestaurantControl ctrl = (RestaurantControl)LoadControl("RestaurantControl.ascx");
                
                
                ctrl.ResTitle = "Restaurant " + i;
                ctrl.ResDescription = "Description";
                ctrl.ResAddress = "" + i + "" + i + "" + i + "" + i + " Main Street";
                ctrl.ResImage = "img/trending/trending-" + i + ".jpg";
                //ctrl.DataBind();
                if (i % 2 == 0)
                {
                    divRestaurantColumn.Controls.Add(ctrl);
                }
                else
                {
                    divRestaurantColumn2.Controls.Add(ctrl);
                }
            }
        }
    }
}