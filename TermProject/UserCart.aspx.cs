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
                GetOrderItems();
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

        }

        protected void lbPaymentInfo_Click(object sender, EventArgs e)
        {

        }

        protected void lbCurrentOrders_Click(object sender, EventArgs e)
        {

        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {

        }

        protected void rptOrderItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeleteItem")
            {
                HiddenField hfID = (HiddenField)e.Item.FindControl("hfOrderItemID");
                int itemID = Convert.ToInt32(hfID.Value);

            }
        }
    }
}