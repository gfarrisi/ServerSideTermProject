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
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["OrderConfirmed"] == null)
            {
                warning.Visible = true;
                dvPanel.Visible = false;
                pnlMenu.Visible = false;
                return;
            }
            if (!IsPostBack)
            {
                GetCookieData();
                GetOrderItems();
            }
            o = (Order)Session["OrderConfirmed"];
            OrderID = o.OrderID;
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
            o = (Order)Session["OrderConfirmed"];
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
                string status = drMyOrder[3].ToString();
                lblStatus.Text = status + "<br/>";
                if(status.Equals("Not Submitted"))
                {
                    imgStatus.Src = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Antu_geany-close-all.svg/240px-Antu_geany-close-all.svg.png";
                }
                else if (status.Equals("Submitted"))
                {
                    imgStatus.Src = "https://upload.wikimedia.org/wikipedia/commons/8/84/Songbird_Icon_Spinner.gif";
                }
                else if(status.Equals("Being Prepared")){
                    imgStatus.Src = "https://upload.wikimedia.org/wikipedia/commons/8/8e/Bundesarchiv_Bild_183-1990-0321-031%2C_Interhotel_%22Stadt_Berlin%22%2C_Auszubildende.jpg";
                }
                else if(status.Equals("Being Delivered"))
                {
                    imgStatus.Src = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/50/Suzuki_Liana_front_20080208.jpg/640px-Suzuki_Liana_front_20080208.jpg";
                }
                else if (status.Equals("Completed"))
                {
                    imgStatus.Src = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c7/Filet_de_b%C5%93uf.jpg/640px-Filet_de_b%C5%93uf.jpg";
                    Session.Remove("OrderConfirmed");
                }
                else if (status.Equals("Problem"))
                {
                    imgStatus.Src = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/67/Antu_package_development_debugger.svg/480px-Antu_package_development_debugger.svg.png";
                }
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
        protected void lbTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllTransactions.aspx");
        }
    }
}