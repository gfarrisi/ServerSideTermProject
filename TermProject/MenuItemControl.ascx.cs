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
            if(Session["Order"] == null)
            {
                o = new Order();
            }
            else
            {
                o = (Order)Session["Order"];
            }
            OrderItem oi = new OrderItem();
            oi.MenuItemID = ItemID;
            List<string> configvalues = new List<string>();
            foreach(RepeaterItem item in repeaterCustomControls.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    DropDownList ddl = (DropDownList)item.FindControl("ddItemConfigurableValues");
                    configvalues.Add(ddl.SelectedValue);
                }
            }
            if(configvalues.Count > 0)
            {
                oi.ConfigurablesString = configvalues;
            }
            o.OrderItemList.Add(oi);
            Session.Add("Order", o);
        }
    }
}