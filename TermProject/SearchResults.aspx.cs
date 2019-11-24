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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["search"]))
            {
                String strName = Request.QueryString["search"];
                Response.Write(strName);
                return;
            }
            //get dataset from viewstate, if it exists
            ds = (DataSet)ViewState["DataSet"];
            Response.Write(ds.ToString());
            if (ds == null)
            {
                //retrieve database for the first time
                Response.Write("Need database");
                SqlCommand sqlGetRestaurants = new SqlCommand();
                sqlGetRestaurants.CommandType = CommandType.StoredProcedure;
                sqlGetRestaurants.CommandText = "TP_GetAllRestaurants";
                ds = objDB.GetDataSetUsingCmdObj(sqlGetRestaurants);
                ViewState.Add("DataSet", ds);
            }
            DrawSearchResults();
        }

        void DrawSearchResults()
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                RestaurantControl ctrl = (RestaurantControl)LoadControl("RestaurantControl.ascx");
                Response.Write("Writing results");
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