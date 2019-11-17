using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using Utilities;
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
            if(chkSameAsDelivery.Checked == true)
            {
                txtBillingAddress.Text = txtDeliveryAddress.Text;
                txtBillingCity.Text = txtDeliveryCity.Text;
                txtBillingState.Text = txtDeliveryState.Text;
                txtBillingZip.Text = txtDeliveryZip.Text;
            }
            else
            {
                txtBillingAddress.Text ="";
                txtBillingCity.Text = "";
                txtBillingState.Text = "";
                txtBillingZip.Text = "";
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string accountType = "User";
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string contactEmail = txtContactEmail.Text;
            string deliveryaddress = txtDeliveryAddress.Text;
            string deliverycity = txtDeliveryCity.Text;
            string deliverystate = txtDeliveryState.Text;
            string deliveryzip = txtDeliveryZip.Text;
            string billingaddress = txtBillingAddress.Text;
            string billingcity = txtBillingCity.Text;
            string billingstate = txtBillingState.Text;
            string billingzip = txtBillingZip.Text;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUser";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@UserID", email);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            if (myDT.Rows.Count > 0)
            {
                lblError.Visible = true;
                Response.Write("<script>alert('Account already exists. Please try again with new email.');</script>");
                lblError.Text = "Account already exists. Please try again with new email.";
            }
            else
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CreateUser";
                objCommand.Parameters.Clear();

                //objCommand.Parameters.AddWithValue("@FirstName", firstName);
                //objCommand.Parameters.AddWithValue("@LastName", lastName);
                //objCommand.Parameters.AddWithValue("@Email", email);
                //objCommand.Parameters.AddWithValue("@UserID", email);
                //objCommand.Parameters.AddWithValue("@Password", password);
                //objCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                //objCommand.Parameters.AddWithValue("@Birthdate", birthday);
                //objCommand.Parameters.AddWithValue("@ContactEmail", contactEmail);
                //objCommand.Parameters.AddWithValue("@Address", address);
                //objCommand.Parameters.AddWithValue("@City", city);
                //objCommand.Parameters.AddWithValue("@State", state);
                //objCommand.Parameters.AddWithValue("@AvatarPath", avatar);
                //objCommand.Parameters.AddWithValue("@Type", account);
                //objCommand.Parameters.AddWithValue("@Active", active);
                //objCommand.Parameters.AddWithValue("@BannedText", banned);

                //int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

                //if (returnValue > 0)
                //{
                //    Response.Write("<script>alert('Account Created');</script>");
                //    //check to see if email already exists 
                //    //store email as user session ID
                //    //redirect to either admin home or user home
                //    Session["EmailID"] = email;
                //    if (account.Equals("User"))
                //    {
                //        Response.Redirect("Home.aspx");
                //    }
                //    else if (account.Equals("Admin"))
                //    {
                //        Response.Redirect("Admin.aspx");
                //    }

                //}
                //else
                //{
                //    Response.Write("<script>alert('Account Not Created');</script>");
                //}
            }




        }
    }
    }
//}