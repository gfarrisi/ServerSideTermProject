using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using FoodOrderingUtils;
using System.Globalization;

namespace TermProject
{
    public partial class RestaurantRegistration : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = txtFirstName.Text;
                string lname = txtLastName.Text;
                string repEmail = txtContactEmail.Text;
                string pword = txtPassword.Text;
                string accounttype = "Rep";
                string cemail = txtContactEmail.Text;
                string resname = txtResName.Text;
                string resimg = txtResImg.Text;
                string resphone = txtResPhone.Text;
                string resemail = txtResEmail.Text;
                string resaddr = txtResAddr.Text;
                string rescity = txtResCity.Text;
                string resstate = ddlResState.SelectedValue;
                string reszip = txtResZip.Text;
                string accountName = txtAccountName.Text;
                string accountType = txtAccountType.Text;
                int accountNumber = Convert.ToInt32(txtAccountNumber.Text);
                float balance = 0;

                //create virtual wallet
                string VirtualWalletID = resemail;
                //get api key info
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetAPIKey";
                objCommand.Parameters.Clear();

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable myDT = myDS.Tables[0];

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
                            sqlRegisterRestaurantRep.CommandText = "TP_CreateRestaurantAndRep";
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@First_Name", fname);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Last_Name", lname);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Rep_Email", repEmail);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Password", pword);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Account_Type", accounttype);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Rep_Contact_Email", cemail);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Restaurant_Name", resname);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Image_URL", resimg);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Restaurant_Email", resemail);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Restaurant_Phone", resphone);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Restaurant_Address", resaddr);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Restaurant_City", rescity);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Restaurant_State", resstate);
                            sqlRegisterRestaurantRep.Parameters.AddWithValue("@Restaurant_ZIP", reszip);
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
                            secError.Visible = true;
                        }
                    }
                    else
                    {
                        secError.Visible = true;
                        secError.InnerText = "A problem occurred while creating your virtual payment wallet id.";
                    }
                }
                catch (Exception ex)

                {
                    secError.Visible = true;
                    secError.InnerText = "Error: " + ex.Message;

                }
                
            }
            catch (Exception ex)
            {
                secError.Visible = true;
                secError.InnerText = "Error: " + ex.Message;
            }


        }
    }
}