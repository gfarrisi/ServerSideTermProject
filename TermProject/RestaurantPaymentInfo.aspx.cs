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
    public partial class RestaurantPaymentInfo : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        String webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug35007/WebAPI/api/service/paymentgateway/GetBalance/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPaymentInfo();
            }

        }
        public void BindPaymentInfo()
        {
            // int restaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
            int restaurantID = 401;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRestaurant";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@RestaurantID", restaurantID);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            rptPaymentInfo.DataSource = myDT;
            rptPaymentInfo.DataBind();

            rptContactInfo.DataSource = myDT;
            rptContactInfo.DataBind();

            string restaurantEmail = myDT.Rows[0]["Restaurant_Email"].ToString();
            Session["RestaurantEmail"] = restaurantEmail;
            GetBalance(restaurantEmail);
        }

        public void GetBalance(string VirtualWalletID)
        {
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

            WebRequest request = WebRequest.Create(webApiUrl + APIKey + "/" + MerchantID + "/" + VirtualWalletID);
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
               
                lblErrorDisplay.Text = "";
                lblErrorDisplay.Visible = false;
            }
            else
            {
                lblErrorDisplay.Text = "No balance found for this account!";               
            }
           
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

        protected void btnFundAccount_Click(object sender, EventArgs e)
        {
            //Please enter a decimal value
            try
            {
                float amount = float.Parse(txtAmount.Text, CultureInfo.InvariantCulture.NumberFormat);
                string VirtualWalletID = Session["RestaurantEmail"].ToString();
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
                        lblErrorDisplay.Visible = true;
                        lblErrorDisplay.Text = "The account was successfully funded.";
                        GetBalance(VirtualWalletID);
                    }

                    else
                    {
                        lblErrorDisplay.Visible = true;
                        lblErrorDisplay.Text = "A problem occurred while adding the funds to the account. The data wasn't recorded.";
                    }


                }
                catch (Exception ex)

                {
                    lblErrorDisplay.Visible = true;
                    lblErrorDisplay.Text = "Error: " + ex.Message;

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
            var btn = (Button)sender;
          //  ContentPlaceHolder item = (ContentPlaceHolder)btn.NamingContainer;
            TextBox accountType = (TextBox)pnlPaymentInfo.FindControl("txtAccountType");
            TextBox accountNumber = rptPaymentInfo.FindControl("txtAccountNumber") as TextBox;

            //Please enter a decimal value
            if (accountType.Text.Length > 0 && accountNumber.Text.Length > 0)
            {
                float amount = float.Parse(txtAmount.Text, CultureInfo.InvariantCulture.NumberFormat);
                string VirtualWalletID = Session["RestaurantEmail"].ToString();
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

                    WebRequest request = WebRequest.Create(webApiUrl + "FundAccount/");
                    request.Method = "POST";
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
                        lblErrorDisplay.Visible = true;
                        lblErrorDisplay.Text = "The account was successfully funded.";
                        GetBalance(VirtualWalletID);
                    }

                    else
                    {
                        lblErrorDisplay.Visible = true;
                        lblErrorDisplay.Text = "A problem occurred while adding the funds to the account. The data wasn't recorded.";
                    }


                }
                catch (Exception ex)

                {
                    lblErrorDisplay.Visible = true;
                    lblErrorDisplay.Text = "Error: " + ex.Message;

                }
            }
            else
            {
                lblErrorDisplay.Visible = true;
                lblErrorDisplay.Text = "Please enter a decimal value to fund this account.";
            }
        }
    }
}