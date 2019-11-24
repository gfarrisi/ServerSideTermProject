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

namespace MerchantRegistration
{
    public partial class RegisterMerchant : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect(true);
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegisterMerchant_Click(object sender, EventArgs e)
        {
            string merchantName = txtMerchantName.Text;
            string merchantID = txtMerchantID.Text;

            if (!(merchantName.Length > 0 & merchantID.Length > 0))
            {
                lblError.Visible = true;
                lblError.Text = "Please enter Merchant Name and ID to continue.";
            }
            else
            {


                //Where should we store apiKEY?


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "PP_GetMerchant";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@MerchantID", merchantID);
                objCommand.Parameters.AddWithValue("@MerchantName", merchantName);

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable myDT = myDS.Tables[0];
                if (myDT.Rows.Count > 0)
                {
                    lblError.Visible = true;
                    lblError.Text = "Account already exists. Please try again with new id.";
                }
                else
                {

                    string apiKey = RandomString(12);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "PP_RegisterMerchant";
                    objCommand.Parameters.Clear();

                    objCommand.Parameters.AddWithValue("@MerchantID", merchantID);
                    objCommand.Parameters.AddWithValue("@MerchantName", merchantName);
                    objCommand.Parameters.AddWithValue("@API_Key", apiKey);

                    int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

                    if (returnValue > 0)
                    {
                        Response.Write("<script>alert('Account Created. Your API Key is "+apiKey + ". Please use this along with your Merhcant ID to access the Boston Payments system.');</script>");
                        //check to see if email already exists 
                        //store email as user session ID
                        //redirect to either admin home or user home
                        //Session["EmailID"] = email;
                        //if (account.Equals("User"))
                        //{
                        //    Response.Redirect("Home.aspx");
                        //}
                        //else if (account.Equals("Admin"))
                        //{
                        //    Response.Redirect("Admin.aspx");
                        //}

                    }
                    else
                    {
                        Response.Write("<script>alert('Account Not Created');</script>");
                    }
                }
            }
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}