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
    public partial class Forgot : System.Web.UI.Page
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
            objCommand.CommandText = "TP_GetUserByBackupEmail";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@Backup_Email", email);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            if (myDT.Rows.Count > 0)
            {
                Email objEmail = new Email();
                String strTO = email;
                String strFROM = "noreply@locals.com";
                String strSubject = "Forgot Email";
                String strMessage = "Your account email is " + myDT.Rows[0]["Email"].ToString() + ". Please return to http://cis-iis2.temple.edu/Fall2019/CIS3342_tug35007/TermProject/Login.aspx to sign in."; ;

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
            lblSent.Text = "If backup email, " + email + " has a valid account associated an email will be sent with the account email.";


        }
    }

}
