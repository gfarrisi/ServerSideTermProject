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
    public partial class RestaurantRegistration : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
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
                int i = objDB.DoUpdateUsingCmdObj(sqlRegisterRestaurantRep);

                //add success code here
                if (i > 0)
                {
                    secError.Visible = false;
                    secContent.Visible = false;
                    secSuccess.Visible = true;
                }
            }
            catch (Exception ex)
            {
                secError.Visible = true;
            }


        }
    }
}