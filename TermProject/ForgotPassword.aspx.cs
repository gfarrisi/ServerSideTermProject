using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace TermProject
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblEnterEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF5581");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
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
                Email objEmail = new Email();
                String strTO = email;
                String strFROM = "noreply@locals.com";
                String strSubject = "Forgot Password";
                String strMessage = "Your account password is " + myDT.Rows[0]["Password"].ToString() + ". Please return to http://cis-iis2.temple.edu/Fall2019/CIS3342_tug35007/TermProject/Login.aspx to sign in.";

                try
                {
                    objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                    //  lblDisplay.Text = "The email was sent.";
                }
                catch (Exception ex)
                {
                    //lblDisplay.Text = "The email wasn't sent because one of the required fields was missing.";
                }

            }
            else
            {

            }


            lblSent.Visible = true;
            lblSent.Text = "If the email, " + email + " has a valid account associated an email will be sent with the account email.";


        }
    }
}