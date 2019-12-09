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
    public partial class OrderStatus : System.Web.UI.Page
    {
        Order o;
        int OrderID;
        DBConnect objDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            o = (Order)Session["Order"];
            OrderID = o.OrderID;
            //OrderID = 39;
             SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCurrentOrder";
            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@OrderID", OrderID);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            if (ds != null)
            {
                DataRow drMyOrder = ds.Tables[0].Rows[0];
                lblID.Text = drMyOrder[0].ToString();
                lblTime.Text = drMyOrder[4].ToString();
                decimal cost = decimal.Parse(drMyOrder[2].ToString());
                lblCost.Text = cost.ToString("C2");
                lblStatus.Text = drMyOrder[3].ToString();
            }
        }

        protected void tmOrderStatus_Tick(object sender, EventArgs e)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCurrentOrder";
            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@OrderID", OrderID);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            if (ds != null)
            {
                DataRow drMyOrder = ds.Tables[0].Rows[0];
                lblStatus.Text = drMyOrder[3].ToString();
            }
        }

        protected void lbAccountSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserAccountSettings.aspx");
        }

        protected void lbPaymentInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentInfo.aspx");
        }

        protected void lbCurrentOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderStatus.aspx");
        }

    }
}