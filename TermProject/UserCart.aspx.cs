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
    public partial class UserCart : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        Order o;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCookieData();
                if (Session["Order"] != null)
                {
                    GetOrderItems();
                }
                else
                {
                    warning.Visible = true;
                    pnlMenu.Visible = false;
                }
            }
        }
        public void GetCookieData()
        {
            HttpCookie cookie = Request.Cookies["VisitorSessionID"];
            if (Session["Email"] == null || Session["AccountType"].ToString() != "Customer")
            {
                Response.Redirect("Default.aspx");
            }
            else if (cookie != null)
            {
                string email = cookie.Value.ToString();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetUser";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@Email", email);

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable myDT = myDS.Tables[0];

                string type = myDT.Rows[0]["Account_Type"].ToString();
                Session["Email"] = email;
                Session["AccountType"] = type;
            }
        }
        private void GetOrderItems()
        {
            o = (Order)Session["Order"];
            int orderID = o.OrderID;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllOrderItemsFromOrder";
            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@OrderID", o.OrderID);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            rptOrderItems.DataSource = myDT;
            rptOrderItems.DataBind();
            Decimal total = (Decimal)o.OrderTotalCost;
            lblTotal.Text = "Total: " + total.ToString("C2");
            if (myDT.Rows.Count == 0)
            {
                Session.Remove("orderRes");
                warning.Visible = true;
                pnlMenu.Visible = false;
            }
        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {

            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField field = args.Item.FindControl("hfOrderItemID") as HiddenField;
                int OrderItemID = Convert.ToInt32(field.Value);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetOrderItemConfigurable";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@OrderItemID", OrderItemID);

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable myDT = myDS.Tables[0];
                Repeater rptItemConfigurables = (Repeater)args.Item.FindControl("rptItemConfigurables");
                rptItemConfigurables.DataSource = myDT;
                rptItemConfigurables.DataBind();
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

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserOrder.aspx");
        }
        protected void lbTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllTransactions.aspx");
        }

        protected void rptOrderItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeleteItem")
            {
                HiddenField hfID = (HiddenField)e.Item.FindControl("hfOrderItemID");
                int itemID = Convert.ToInt32(hfID.Value);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_DeleteOrderItem";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@OrderItemID", itemID);
                int result = objDB.DoUpdateUsingCmdObj(objCommand);
                    GetOrderItems();
            }
        }

        protected void btnClearOrder_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptOrderItems.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfID = (HiddenField)item.FindControl("hfOrderItemID");
                    int itemID = Convert.ToInt32(hfID.Value);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_DeleteOrderItem";
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@OrderItemID", itemID);
                    int result = objDB.DoUpdateUsingCmdObj(objCommand);
                }
            }
            Session.Remove("orderRes");
            GetOrderItems();
        }
    }
}