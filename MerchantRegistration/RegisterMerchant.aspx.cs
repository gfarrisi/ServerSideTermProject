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
                int apiKey = 1001;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "PP_RegisterMerchant";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@MerchantID", merchantID);
                objCommand.Parameters.AddWithValue("@MerchantName", merchantName);
                objCommand.Parameters.AddWithValue("@API_Key", apiKey);

                int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

                if (returnValue > 0)
                {
                    Response.Write("<script>alert('Account Created');</script>");
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
}