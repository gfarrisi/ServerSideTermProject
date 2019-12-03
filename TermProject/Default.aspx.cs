using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Data;

namespace TermProject
{
    public partial class Default : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateLinkColors();
        }


        public void UpdateLinkColors()
        {
            lbCreateAccount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF5581");
            lbForgotEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF5581");
            lbForgotPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF5581");
            //#FF5581
        }

        protected void lbForgotEmail_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotEmail.aspx");
        }
        protected void lbForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
        protected void lbCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChooseAccountType.aspx");
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (email.Length <= 0 || password.Length <= 0)
            {
                lblError.Visible = true;
                lblError.Text = "* Please make sure both email and password have been entered.";
            }
            else
            {

                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_LogIn";
                objCommand.Parameters.Clear();


                SqlParameter inputParameter = new SqlParameter("@Email", email);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                objCommand.Parameters.Add(inputParameter);

                inputParameter = new SqlParameter("@Password", password);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                objCommand.Parameters.Add(inputParameter);

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                //check if user is in database
                if (myDS.Tables[0].Rows.Count == 0)
                {
                    lblError.Visible = true;
                    lblError.Text = "No active account was found with that email and password please try again.";
                }
                else
                {

                    lblError.Visible = false;
                    string type = myDS.Tables[0].Rows[0]["Account_Type"].ToString();
                    Session["Email"] = email;
                    Session["AccountType"] = type;
                    if (type.Equals("Customer"))
                    {
                        Response.Redirect("LandingPage.aspx");
                    }
                    else if (type.Equals("Rep"))
                    {
                        //get restaurant id and add to session storage

                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "TP_GetRestaurantFromRep";
                        objCommand.Parameters.Clear();

                        objCommand.Parameters.AddWithValue("@Representative_Email", email);

                        DataSet DS = objDB.GetDataSetUsingCmdObj(objCommand);
                        string restaurantID = DS.Tables[0].Rows[0]["Restaurant_ID"].ToString();
                        Session["RestaurantID"] = restaurantID;
                        Response.Redirect("RestaurantLanding.aspx");
                    }
                    else
                    {
                        lblError.Text = "<p>* Error: log in data could not be processed.</p>";
                    }


                }


            }
        }
    }
}