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
    public partial class SearchResults : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        DataSet ds;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //get dataset from viewstate, if it exists
            ds = (DataSet)ViewState["DataSet"];
            if (ds == null)
            {
                //retrieve database for the first time
                SqlCommand sqlGetRestaurants = new SqlCommand();
                sqlGetRestaurants.CommandType = CommandType.StoredProcedure;
                sqlGetRestaurants.CommandText = "TP_GetAllRestaurants";
                ds = objDB.GetDataSetUsingCmdObj(sqlGetRestaurants);
                ViewState.Add("DataSet", ds);
            }

            String strName = Request.QueryString["search"];
            //Response.Write(strName);
            if (ds != null)

                dt = ds.Tables[0];
            if (!String.IsNullOrEmpty(strName))
            {
                dt.DefaultView.RowFilter = "Restaurant_Name Like '%" + strName + "%'";
            }
            if (dt != null)
            {
                DrawSearchResults();
            }
        }

        void DrawSearchResults()
        {
            if (dt.DefaultView.Count > 0)
            {
                int i = 0;
                foreach (DataRow drv in dt.DefaultView.ToTable().Rows)
                {
                    RestaurantControl ctrl = (RestaurantControl)LoadControl("RestaurantControl.ascx");
                    ctrl.ResTitle = drv[1].ToString();
                    ctrl.ResAddress = drv[5].ToString();
                    ctrl.ResImage = drv[2].ToString();
                    if (i % 2 == 0)
                    {
                        divRestaurantColumn.Controls.Add(ctrl);
                        i++;
                    }
                    else
                    {
                        divRestaurantColumn2.Controls.Add(ctrl);
                        i++;
                    }
                }
            }
        }
    }
}