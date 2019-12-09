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
    public partial class RestaurantCurrentOrders : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        // int restaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
        int restaurantID = 400;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCookieData();
                GetOrderStatus();
                DrawContactInfo();
            }
        }
        public void GetCookieData()
        {
            HttpCookie cookie = Request.Cookies["VisitorSessionID"];
            if (Session["Email"] == null || Session["AccountType"].ToString() != "Rep")
            {
                Response.Redirect("Default.aspx");
            }
            else if (cookie != null)
            {
                string restaurantRepEmail = cookie.Value.ToString();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetUser";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@Email", restaurantRepEmail);

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable myDT = myDS.Tables[0];

                string type = myDT.Rows[0]["Account_Type"].ToString();
                Session["Email"] = restaurantRepEmail;
                Session["AccountType"] = type;


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetRestaurantFromRep";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@Representative_Email", restaurantRepEmail);

                myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                myDT = myDS.Tables[0];

                int restaurantID = Convert.ToInt32(myDT.Rows[0]["Restaurant_ID"].ToString());
                Session["RestaurantID"] = restaurantID;
            }
        }
        public void DrawContactInfo() {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRestaurant";
            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@RestaurantID", restaurantID);
            DataSet DS2 = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = DS2.Tables[0];
            rptContactInfo.DataSource = myDT;
            rptContactInfo.DataBind();
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
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            string txtName = row.Cells[0].Text;
            int resID = int.Parse(txtName);

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateOrderStatus";
            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@OrderID", resID);
            objCommand.Parameters.AddWithValue("@OrderStatus", ddl.SelectedValue);
            int result = objDB.DoUpdateUsingCmdObj(objCommand);
            if (result > 0)
            {
                Label lblUpdate = (Label)row.Cells[5].FindControl("lblUpdate");
                lblUpdate.Text = "✅";
            }
            else
            {
                Response.Write("Error setting order status");
            }
           // gvOrders.DataBind();
           //GetOrderStatus();
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