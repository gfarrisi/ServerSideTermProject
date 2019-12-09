using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodOrderingUtils;
using Newtonsoft.Json;
using Utilities;

namespace TermProject
{
    public partial class MenuItemControl : System.Web.UI.UserControl
    {
        DBConnect objDB = new DBConnect();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int ItemID
        {
            get;set;
        }

        public int RestaurantID
        {
            get; set;
        }
        //for transactions
        public string RestaurantEmail
        {
            get; set;
        }

        public String ItemName
        {
            get { return txtItemName.InnerText; }
            set { txtItemName.InnerText = value; }
        }

        public String ItemDescription
        {
            get { return txtItemDescription.InnerText; }
            set { txtItemDescription.InnerText = value; }
        }

        public String ItemPrice
        {
            get { return txtPrice.InnerText; }
            set { txtPrice.InnerText = value; }
        }

        public String ItemImage
        {
            get { return imgMenuItem.Src; }
            set { imgMenuItem.Src = value; }
        }

        public String ItemCategory
        {
            get { return txtCategory.InnerText; }
            set { txtCategory.InnerText = value; }
        }

        public void GetConfigurables(int ItemID)
        {
            SqlCommand sqlGetConfigurables = new SqlCommand();
            sqlGetConfigurables.CommandType = CommandType.StoredProcedure;
            sqlGetConfigurables.CommandText = "TP_Get_Menu_Item_Configurable";
            sqlGetConfigurables.Parameters.AddWithValue("@Menu_Item_ID", ItemID);
            DataSet ds = objDB.GetDataSetUsingCmdObj(sqlGetConfigurables);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                repeaterCustomControls.DataSource = dt;
                DataBind();
            }
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType ==
            ListItemType.AlternatingItem)
            {
                DataRow current = dt.Rows[e.Item.ItemIndex];
                //Find the Label in repeater
                Label lblConfigurableTitle = (e.Item.FindControl("lblItemConfigurableTitle") as Label);
                string title = current[3].ToString();
                //Find the DropDownList in the Repeater Item.
                DropDownList ddlConfigurableOptions = (e.Item.FindControl("ddItemConfigurableValues") as DropDownList);
                string json = current[3].ToString();
                List<string> values = JsonConvert.DeserializeObject<List<string>>(Server.UrlDecode(json));
                ddlConfigurableOptions.DataSource = values;
                ddlConfigurableOptions.DataBind();
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            Order o;
            bool newOrder;
            if(Session["Order"] == null)
            {
                o = new Order();
                newOrder = true;
            }
            else
            {
                o = (Order)Session["Order"];
                newOrder = false;
            }
            if (Session["orderRes"] != null)
            {
                string orderRes = (string)Session["orderRes"];
                if (orderRes != RestaurantEmail)
                {
                    Response.Write("You already have items from another restaurant in your cart. Delete those before you order from this place.");
                    return;
                }
            }
            OrderItem oi = new OrderItem();
            oi.MenuItemID = ItemID;
            oi.OrderItemPrice = Single.Parse(ItemPrice, System.Globalization.NumberStyles.Currency);
            List<OrderConfigurableItem> configvalues = new List<OrderConfigurableItem>();
            foreach(RepeaterItem item in repeaterCustomControls.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    OrderConfigurableItem oci = new OrderConfigurableItem();
                    Label lbl = (Label)item.FindControl("lblItemConfigurableTitle");
                    DropDownList ddl = (DropDownList)item.FindControl("ddItemConfigurableValues");
                    oci.Title = lbl.Text;
                    oci.Value = ddl.SelectedItem.Text;
                    configvalues.Add(oci);
                }
            }
            if(configvalues.Count > 0)
            {
                oi.Configurables = configvalues;
            }
            o.OrderItemList.Add(oi);
            o.OrderStatus = "Not Submitted";
            Session.Add("Order", o);
            //oh boy let's add the order to the database

            //update order
            SqlCommand sqlAddOrder = new SqlCommand();
            sqlAddOrder.CommandType = CommandType.StoredProcedure;
            if (newOrder)
            {
                sqlAddOrder.CommandText = "TP_CreateOrder";
            }
            else
            {
                sqlAddOrder.CommandText = "TP_UpdateOrder";
                sqlAddOrder.Parameters.AddWithValue("OrderID", o.OrderID);
            }
            sqlAddOrder.Parameters.AddWithValue("@OrderRestaurantID", RestaurantID);
            string customerEmail = (string)Session["Email"];
            customerEmail = "gabriellafarrisi@gmail.com";
            sqlAddOrder.Parameters.AddWithValue("@OrderCustomerEmail", customerEmail);
            o.CalculateCost();
            sqlAddOrder.Parameters.AddWithValue("@OrderTotalCost", o.OrderTotalCost);
            sqlAddOrder.Parameters.AddWithValue("@OrderStatus", o.OrderStatus);
            sqlAddOrder.Parameters.AddWithValue("@OrderTime", DateTime.Now);
            SqlParameter returnParameter = sqlAddOrder.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            objDB.DoUpdateUsingCmdObj(sqlAddOrder);
            if (newOrder)
            {
                o.OrderID = (int)returnParameter.Value;
                System.Diagnostics.Debug.WriteLine(o.OrderID + "");
            }
            oi.OrderID = o.OrderID;
            //add order item
            SqlCommand sqlAddOrderItem = new SqlCommand();
            sqlAddOrderItem.CommandType = CommandType.StoredProcedure;
            sqlAddOrderItem.CommandText = "TP_CreateOrderItem";
            sqlAddOrderItem.Parameters.AddWithValue("@OrderID", o.OrderID);
            sqlAddOrderItem.Parameters.AddWithValue("@MenuItemID", ItemID);
            SqlParameter returnParameterItem = sqlAddOrderItem.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameterItem.Direction = ParameterDirection.ReturnValue;
            objDB.DoUpdateUsingCmdObj(sqlAddOrderItem);
            oi.OrderItemID = (int)returnParameterItem.Value;
            //add any configurables
            foreach (OrderConfigurableItem oci in oi.Configurables)
            {
                oci.OrderItemID = oi.OrderItemID;
                SqlCommand sqlAddOrderItemConfigurable = new SqlCommand();
                sqlAddOrderItemConfigurable.CommandType = CommandType.StoredProcedure;
                sqlAddOrderItemConfigurable.CommandText = "TP_CreateOrderConfigurableItem";
                sqlAddOrderItemConfigurable.Parameters.AddWithValue("@OrderItemID", oi.OrderItemID);
                sqlAddOrderItemConfigurable.Parameters.AddWithValue("@OrderItemConfigurableTitle", oci.Title);
                sqlAddOrderItemConfigurable.Parameters.AddWithValue("@OrderItemConfigurableValue", oci.Value);
                sqlAddOrderItemConfigurable.Parameters.AddWithValue("@MenuItemID", ItemID);
                SqlParameter returnParameterItemConfig = sqlAddOrderItem.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameterItemConfig.Direction = ParameterDirection.ReturnValue;
                objDB.DoUpdateUsingCmdObj(sqlAddOrderItemConfigurable);
                oci.OrderConfigurableID = (int)returnParameterItem.Value;
            }
            Session["orderRes"] = RestaurantEmail;
            Session.Add("Order", o);
            Response.Write(ItemName + " added to order.");
        }
    }
}