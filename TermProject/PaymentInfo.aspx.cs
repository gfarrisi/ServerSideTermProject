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
using System.Net;
using System.IO;
using FoodOrderingUtils;
using System.Globalization;

namespace TermProject
{
    public partial class PaymentInfo : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCookieData();
                BindPaymentInfo();
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
        public void BindPaymentInfo()
        {
            string email = Session["Email"].ToString();
            //string email = "gabriellafarrisi@gmail.com";

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetUser";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@Email", email);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            rptPaymentInfo.DataSource = myDT;
            rptPaymentInfo.DataBind();
            GetBalance();
        }
        public void GetBalance()
        {
            //take from session
            string email = Session["Email"].ToString();
            //string email = "gabriellafarrisi@gmail.com";

            //get api key info
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAPIKey";
            objCommand.Parameters.Clear();

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];

            string APIKey = myDT.Rows[0]["API_Key"].ToString();
            string MerchantID = myDT.Rows[0]["ID"].ToString();

            //call api
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            String webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug35007/WebAPI/api/service/paymentgateway/GetBalance/";

            WebRequest request = WebRequest.Create(webApiUrl + APIKey + "/" + MerchantID + "/" + email);
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            //// Deserialize a JSON string into a Team object.
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Team team = js.Deserialize<Team>(data);

            //set balance
            if (data != "")
            {
                lblBalance.Text = String.Format("{0:C}", Convert.ToDecimal(data));
                Session["AccountBalace"] = data;
                lblErrorDisplay.Text = "";
                lblErrorDisplay.Visible = false;
            }
            else
            {
                lblErrorDisplay.Text = "No balance found for this account!";
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
        protected void btnFundAccount_Click(object sender, EventArgs e)
        {
            //Please enter a decimal value
            try
            {
                float amount = float.Parse(txtAmount.Text, CultureInfo.InvariantCulture.NumberFormat);
                if (amount > 0)
                {
                    string VirtualWalletID = Session["Email"].ToString();
                    //string VirtualWalletID = "gabriellafarrisi@gmail.com";
                    //get api key info
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_GetAPIKey";
                    objCommand.Parameters.Clear();

                    DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                    DataTable myDT = myDS.Tables[0];

                    string APIKey = myDT.Rows[0]["API_Key"].ToString();
                    string MerchantID = myDT.Rows[0]["ID"].ToString();

                    Transaction transaction = new Transaction(APIKey, MerchantID, VirtualWalletID, VirtualWalletID, "Fund", amount);
                    // Serialize a Customer object into a JSON string.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    String jsonCustomer = js.Serialize(transaction);
                    try
                    {
                        // Send the Transaction object to the Web API that will be used to store a new customer record in the database.
                        // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                        String webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug35007/WebAPI/api/service/paymentgateway/";

                        WebRequest request = WebRequest.Create(webApiUrl + "FundAccount/");
                        request.Method = "PUT";
                        request.ContentLength = jsonCustomer.Length;
                        request.ContentType = "application/json";

                        // Write the JSON data to the Web Request
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonCustomer);
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
                            lblPaymentUpdatedMsg.Visible = false;
                            lblFunded.Visible = true;
                            lblFunded.Text = "The account was successfully funded.";
                            GetBalance();
                        }

                        else
                        {
                            lblFunded.Visible = true;
                            lblFunded.Text = "A problem occurred while adding the funds to the account. The data wasn't recorded.";
                        }


                    }
                    catch (Exception ex)

                    {
                        lblErrorDisplay.Visible = true;
                        lblErrorDisplay.Text = "Error: " + ex.Message;

                    }
                }
            }
            catch
            {
                lblErrorDisplay.Visible = true;
                lblErrorDisplay.Text = "Please enter a decimal value to fund this account.";
            }
        }

        //Needs to be worked out!!!!! Can't cast the button value
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptPaymentInfo.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBox accountType = (TextBox)item.FindControl("txtAccountType");
                    TextBox accountNumber = (TextBox)item.FindControl("txtAccountNumber");
                    TextBox accountName = (TextBox)item.FindControl("txtAccountName");
                    //Please enter a decimal value
                    if (accountType.Text.Length > 0 && accountNumber.Text.Length > 0 && accountName.Text.Length > 0)
                    {
                        try
                        {
                            int accountNumberInt = Convert.ToInt32(accountNumber.Text);
                            if (accountNumberInt > 0 && accountNumberInt < 1000000000)
                            {


                                string VirtualWalletID = Session["Email"].ToString();
                                //string VirtualWalletID = "gabriellafarrisi@gmail.com";
                                //get api key info
                                objCommand.CommandType = CommandType.StoredProcedure;
                                objCommand.CommandText = "TP_GetAPIKey";
                                objCommand.Parameters.Clear();

                                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                                DataTable myDT = myDS.Tables[0];

                                string APIKey = myDT.Rows[0]["API_Key"].ToString();
                                string MerchantID = myDT.Rows[0]["ID"].ToString();

                                float balance = float.Parse(Session["AccountBalace"].ToString());

                                AccountHolder accountHolder = new AccountHolder(APIKey, MerchantID, VirtualWalletID, accountName.Text, accountType.Text, accountNumberInt, balance);
                                // Serialize a Customer object into a JSON string.
                                JavaScriptSerializer js = new JavaScriptSerializer();
                                String jsonAccountHolder = js.Serialize(accountHolder);
                                try
                                {
                                    // Send the Transaction object to the Web API that will be used to store a new customer record in the database.
                                    // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                                    String webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug35007/WebAPI/api/service/paymentgateway/";

                                    WebRequest request = WebRequest.Create(webApiUrl + "UpdatePaymentAccount/");
                                    request.Method = "PUT";
                                    request.ContentLength = jsonAccountHolder.Length;
                                    request.ContentType = "application/json";

                                    // Write the JSON data to the Web Request
                                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                                    writer.Write(jsonAccountHolder);
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
                                        //update locals db
                                        //TP_UpdateRestaurantPaymentInfo

                                        objCommand.CommandType = CommandType.StoredProcedure;
                                        objCommand.CommandText = "TP_UpdateCustomerPaymentInfo";
                                        objCommand.Parameters.Clear();
                                        objCommand.Parameters.AddWithValue("@Payment_Account_Type", accountType.Text);
                                        objCommand.Parameters.AddWithValue("@Payment_Account_Number", Convert.ToInt32(accountNumber.Text));
                                        objCommand.Parameters.AddWithValue("@Email", VirtualWalletID);
                                        objCommand.Parameters.AddWithValue("@Payment_Account_Name", accountName.Text);
                                        int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

                                        if (returnValue > 0)
                                        {
                                            lblFunded.Visible = false;
                                            lblPaymentUpdatedMsg.Visible = true;
                                            lblErrorDisplay.Text = "Your payment info was successfully updated.";

                                        }
                                        else
                                        {
                                            lblFunded.Visible = false;
                                            lblPaymentUpdatedMsg.Visible = true;
                                            lblPaymentUpdatedMsg.Text = "*Error: Your payment info was not successfully updated.";

                                        }

                                    }

                                    else
                                    {
                                        lblPaymentUpdatedMsg.Visible = true;
                                        lblPaymentUpdatedMsg.Text = "A problem occurred while updating the payment of the account. The data wasn't recorded.";
                                    }


                                }
                                catch (Exception ex)

                                {
                                    lblPaymentUpdatedMsg.Visible = true;
                                    lblPaymentUpdatedMsg.Text = "Error: " + ex.Message;

                                }
                            }
                            else
                            {
                                lblPaymentUpdatedMsg.Visible = true;
                                lblPaymentUpdatedMsg.Text = "Please enter a positive integer.";
                            }
                        }
                        catch(Exception ex)
                        {
                            lblPaymentUpdatedMsg.Visible = true;
                            lblPaymentUpdatedMsg.Text = "Error: " + ex.Message;
                        }
                    }
                    else
                    {
                        lblPaymentUpdatedMsg.Visible = true;
                        lblPaymentUpdatedMsg.Text = "Please enter a value to update.";
                    }
                }
            }
        }
    }
}