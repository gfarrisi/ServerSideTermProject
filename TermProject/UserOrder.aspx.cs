using FoodOrderingUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TermProject
{
    public partial class UserOrder : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        Order o;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Order"] != null)
            {
                GetOrderItems();
            }
            else
            {
                warning.Visible = true;
                btnOrder.Visible = false;
                pnlMenu.Visible = false;
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
            Response.Redirect("UserOrder.aspx");
        }

        protected void lbTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllTransactions.aspx");
        }


        protected void btnCheckout_Click(object sender, EventArgs e)
        {

        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            //get order
            o = (Order)Session["Order"];
            //get api key info
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAPIKey";
            objCommand.Parameters.Clear();

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];

            string APIKey = myDT.Rows[0]["API_Key"].ToString();
            string MerchantID = myDT.Rows[0]["ID"].ToString();


            //string userEmail = Session["Email"].ToString();
            string userEmail = "gabriellafarrisi@gmail.com";

            string restaurantEmail = (string)Session["orderRes"];
            //make transaction
            Transaction transaction = new Transaction(APIKey, MerchantID, userEmail, restaurantEmail, "Payment", o.OrderTotalCost);
            // Serialize a transaction object into a JSON string.
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonTransaction = js.Serialize(transaction);

            try
            {
                // Send the Transaction object to the Web API that will be used to store a new customer record in the database.
                // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                String webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug53772/WebAPI/api/service/paymentgateway/";

                WebRequest request = WebRequest.Create(webApiUrl + "ProcessPayment/");
                request.Method = "POST";
                request.ContentLength = jsonTransaction.Length;
                request.ContentType = "application/json";

                // Write the JSON data to the Web Request
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonTransaction);
                writer.Flush();
                writer.Close();

                // Read the data from the Web Response, which requires working with streams.
                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data == "true")
                {
                    Decimal total = (Decimal)o.OrderTotalCost;   //cost in $$$
                    lblFunded.Visible = true;
                    lblFunded.Text = "Order successful! Head on over to the <a href='OrderStatus.aspx'>order status page</a> to view the deets.";
                    pnlMenu.Visible = false;
                    //write confirmation email
                    Email objEmail = new Email();
                    //string emailTo = Session["Email"].ToString();
                    string emailTo = "hazel@temple.edu";
                    String strTO = emailTo;
                    String strFROM = "noreply@locals.com";
                    String strSubject = "Your Order Confirmation";
                    String strMessage = "This is a receipt from your Locals order at " + DateTime.Now.ToLongDateString() + "\n Items: " + o.OrderItemList.Count + "\n Cost: " + total.ToString("C2");

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_UpdateOrderStatus";
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@OrderID", o.OrderID);
                    objCommand.Parameters.AddWithValue("@OrderStatus", "Submitted");
                    int result = objDB.DoUpdateUsingCmdObj(objCommand);
                    if(result > 0)
                    {
                        //success
                    }
                    else
                    {
                        Response.Write("Error setting order status");
                    }

                    try
                    {
                        objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Email machine broke");
                    }
                }
                else if(data == "Insufficiant Funds")
                {
                    lblErrorDisplay.Visible = true;
                    lblErrorDisplay.Text = "You don't have enough funds in your account to complete this transaction. Go to your Account Settings page and Payment Info section to add more.";
                }

                else
                {
                    lblErrorDisplay.Visible = true;
                    lblErrorDisplay.Text = "Something unknowable went wrong with this transaction. Good luck.";
                }


            }
            catch (Exception ex)

            {
                lblErrorDisplay.Visible = true;
                lblErrorDisplay.Text = "Error: " + ex.Message;

            }
        }
    }
}
