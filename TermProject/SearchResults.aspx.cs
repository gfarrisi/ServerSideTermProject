using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void DrawSearchResults()
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                RestaurantControl ctrl = (RestaurantControl)LoadControl("RestaurantControl.ascx");

                DataRow drv = ds.Tables[0].Rows[i];
                ctrl.ResTitle = drv[1].ToString();
                ctrl.ResAddress = drv[5].ToString();
                ctrl.ResImage = drv[2].ToString();
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