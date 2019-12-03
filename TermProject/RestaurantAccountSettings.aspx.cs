using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using DatabaseUtilities;
using Utilities;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace TermProject
{
    public partial class RestaurantAccountSettings : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindContactInfo();
            BindRepIngo();
        }

        public void BindContactInfo()
        {
            // int restaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
            int restaurantID = 401;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRestaurant";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@RestaurantID", restaurantID);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            rptRestaurantInfo.DataSource = myDT;
            rptRestaurantInfo.DataBind();
        }

        public void BindRepIngo()
        {
            // string restaurantRepEmail = Session["restaurantRepEmail"].ToString();
            string restaurantRepEmail = "janebackup@gmail.com";

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetUser";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@Email", restaurantRepEmail);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            rptRepInfo.DataSource = myDT;
            rptRepInfo.DataBind();
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