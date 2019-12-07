using FoodOrderingUtils;
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
    public partial class RestaurantOrderStatus : System.Web.UI.Page
    {
        
        DBConnect objDB = new DBConnect();
        // int restaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
        int restaurantID = 401;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetOrderStatus();
        }

        public void GetOrderStatus()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetOrdersByRestaurant";
            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@OrderRestaurantID", restaurantID);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            gvOrders.DataSource = ds;
            gvOrders.DataBind();
        }

        protected void tmOrderStatus_Tick(object sender, EventArgs e)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetOrdersByRestaurant";
            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@RestaurantID", restaurantID);
            //DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateOrderStatus";
            objCommand.Parameters.Clear();
            //objCommand.Parameters.AddWithValue("@OrderID", e.get);
            objCommand.Parameters.AddWithValue("@OrderStatus", "Submitted");
            int result = objDB.DoUpdateUsingCmdObj(objCommand);
            if (result > 0)
            {
                //success
            }
            else
            {
                Response.Write("Error setting order status");
            }
            GetOrderStatus();
        }
    }
}