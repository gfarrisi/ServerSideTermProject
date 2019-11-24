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
    public partial class ViewRestaurant : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        DataSet ds;
        int RestaurantID = 400;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlCommand sqlGetMenu = new SqlCommand();
                sqlGetMenu.CommandType = CommandType.StoredProcedure;
                sqlGetMenu.CommandText = "TP_GetMenuItems";
                sqlGetMenu.Parameters.AddWithValue("@RestaurantID", RestaurantID);
                ds = objDB.GetDataSetUsingCmdObj(sqlGetMenu);
            }
        }
    }
}