using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                RestaurantControl ctrl = (RestaurantControl)LoadControl("RestaurantControl.ascx");
                ctrl.ResTitle = "Restauraunt " + i;
                ctrl.ResDescription = "Description";
                ctrl.ResAddress = "1252 Main Road";
                ctrl.ResImage = "img/trending/trending-" + i + ".jpg";
                //ctrl.DataBind();
                divRestaurantColumn.Controls.Add(ctrl);
            }
        }
    }
}