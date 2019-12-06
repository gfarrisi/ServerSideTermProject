using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using FoodOrderingUtils;
using System.Globalization;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateColors();
        }
        public void UpdateColors()
        {
            lbContactInfo.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF5581");
            lblBiliingInfo.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF5581");
            lblDeliveryInfo.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF5581");
        }

        protected void chkSameAsDelivery_CheckedChanged(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (chkSameAsDelivery.Checked == true)
            {
                txtBillingAddress.Text = txtDeliveryAddress.Text;
                txtBillingCity.Text = txtDeliveryCity.Text;
                ddBillingState.SelectedValue = ddDeliveryState.SelectedValue;
                txtBillingZip.Text = txtDeliveryZip.Text;
            }
            else
            {
                txtBillingAddress.Text = "";
                txtBillingCity.Text = "";
                ddBillingState.SelectedValue = "";
                txtBillingZip.Text = "";
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetUser";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@Email", email);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            if (myDT.Rows.Count > 0)
            {
                lblError.Visible = true;
               // Response.Write("<script>alert('Account already exists. Please try again with new email.');</script>");
                lblError.Text = "Account already exists. Please try again with new email.";
            }
            else
            {
                try
                {

                    string type = "Customer";
                    string firstName = txtFirstName.Text;
                    string lastName = txtLastName.Text;                 
                    string password = txtPassword.Text;
                    string contactEmail = txtContactEmail.Text;
                    string deliveryaddress = txtDeliveryAddress.Text;
                    string deliverycity = txtDeliveryCity.Text;
                    string deliverystate = ddDeliveryState.SelectedValue;
                    string deliveryzip = txtDeliveryZip.Text;
                    string billingaddress = txtBillingAddress.Text;
                    string billingcity = txtBillingCity.Text;
                    string billingstate = ddBillingState.SelectedValue;
                    string billingzip = txtBillingZip.Text;
                    string accountName = txtAccountName.Text;
                    string accountType = txtAccountType.Text;
                    int accountNumber = Convert.ToInt32(txtAccountNumber.Text);
                    float balance = 0;

                    //create virtual wallet
                    string VirtualWalletID = email;
                    //get api key info
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_GetAPIKey";
                    objCommand.Parameters.Clear();

                    myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                    myDT = myDS.Tables[0];

                    string APIKey = myDT.Rows[0]["API_Key"].ToString();
                    string MerchantID = myDT.Rows[0]["ID"].ToString();

                    AccountHolder accountHolder = new AccountHolder(APIKey, MerchantID, VirtualWalletID, accountName, accountType, accountNumber, balance);
                    // Serialize a Customer object into a JSON string.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    String jsonAccountHolder = js.Serialize(accountHolder);
                    try
                    {
                        // Send the Transaction object to the Web API that will be used to store a new customer record in the database.
                        // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                        String webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug35007/WebAPI/api/service/paymentgateway/";

                        WebRequest request = WebRequest.Create(webApiUrl + "CreateVirtualWallet/");
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
                            try
                            {                               
                                SqlCommand sqlRegisterRestaurantRep = new SqlCommand();
                                sqlRegisterRestaurantRep.CommandType = CommandType.StoredProcedure;
                                sqlRegisterRestaurantRep.CommandText = "TP_CreateCustomer";
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@First_Name", firstName);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Last_Name", lastName);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Email", email);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Password", password);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Account_Type", type);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Backup_Email", contactEmail);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Delivery_Address", deliveryaddress);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Delivery_City", deliverycity);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Delivery_State", deliverystate);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Delivery_Zip", deliveryzip);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Billing_Address", billingaddress);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Billing_City", billingcity);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Billing_State", billingstate);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Billing_Zip", billingzip);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Payment_Account_Name", accountName);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Payment_Account_Type", accountType);
                                sqlRegisterRestaurantRep.Parameters.AddWithValue("@Payment_Account_Number", accountNumber);
                                int i = objDB.DoUpdateUsingCmdObj(sqlRegisterRestaurantRep);

                                //add success code here
                                if (i > 0)
                                {
                                    //secError.Visible = false;
                                    //secContent.Visible = false;
                                    //secSuccess.Visible = true;
                                    Response.Write("<script>alert('Your account has been successfully created! Please sign in to access Locals.');</script>");
                                    Response.Redirect("Default.aspx");
                                }
                            }
                            catch (Exception ex)
                            {
                                lblError.Visible = true;
                                lblError.Text = "Error: " + ex.Message;
                            }
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "A problem occurred while creating your virtual payment wallet id.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblError.Visible = true;
                        lblError.Text = "Error: " + ex.Message;

                    }

                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "Error: " + ex.Message;
                }
            }




        }
    }
}
//}