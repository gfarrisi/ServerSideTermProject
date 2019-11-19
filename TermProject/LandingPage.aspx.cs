using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

            if (!IsPostBack)
            {

                SqlCommand sqlGetRestaurants = new SqlCommand();
                sqlGetRestaurants.CommandType = CommandType.StoredProcedure;
                sqlGetRestaurants.CommandText = "TP_GetAllRestaurants";
                DataSet ds = objDB.GetDataSetUsingCmdObj(sqlGetRestaurants);

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
}