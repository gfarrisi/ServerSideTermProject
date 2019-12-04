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

namespace TermProject
{
    public partial class RestaurantAccountSettings : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string restaurantRepEmail = "janebackup@gmail.com";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindContactInfo();
                BindRepInfo();
            }
        }

        public void BindContactInfo()
        {
            // int restaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
            int restaurantID = 401;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRestaurant";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@RestaurantID", restaurantID);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            rptRestaurantInfo.DataSource = myDT;
            rptRestaurantInfo.DataBind();
        }

        public void BindRepInfo()
        {
            // string restaurantRepEmail = Session["restaurantRepEmail"].ToString();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetUser";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@Email", restaurantRepEmail);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            rptRepInfo.DataSource = myDT;
            rptRepInfo.DataBind();
            foreach (RepeaterItem item in rptRepInfo.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBox password = (TextBox)item.FindControl("txtPassword");
                    password.Attributes["type"] = "password";
                }
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand sqlUpdate = new SqlCommand();
            sqlUpdate.CommandType = CommandType.StoredProcedure;
            sqlUpdate.CommandText = "TP_UpdateRestaurantAndRepresentativeInfo";
            sqlUpdate.Parameters.AddWithValue("@Email", restaurantRepEmail);
            foreach (RepeaterItem item in rptRestaurantInfo.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    //TextBox rname = (TextBox)item.FindControl("txtResName");
                    //sqlUpdate.Parameters.AddWithValue("@Restaurant_Name", rname.Text);
                    TextBox rphone = (TextBox)item.FindControl("txtPhone");
                    string phone = rphone.Text;
                    phone.Replace("\\D+", "");
                    sqlUpdate.Parameters.AddWithValue("@Restaurant_Phone", phone);
                    //TextBox remail = (TextBox)item.FindControl("txtResEmail");
                    //sqlUpdate.Parameters.AddWithValue("@Restaurant_Email", remail.Text);
                    TextBox img = (TextBox)item.FindControl("txtImageURL");
                    sqlUpdate.Parameters.AddWithValue("@Image_URL", img.Text);
                    TextBox raddress = (TextBox)item.FindControl("txtAddress");
                    sqlUpdate.Parameters.AddWithValue("@Restaurant_Address", raddress.Text);
                    TextBox rcity = (TextBox)item.FindControl("txtCity");
                    sqlUpdate.Parameters.AddWithValue("@Restaurant_City", rcity.Text);
                    DropDownList rstate = (DropDownList)item.FindControl("txtState");
                    sqlUpdate.Parameters.AddWithValue("@Restaurant_State", rstate.SelectedValue);
                    TextBox rzip = (TextBox)item.FindControl("txtZip");
                    sqlUpdate.Parameters.AddWithValue("@Restaurant_Zip", rzip.Text);
                }
            }

            foreach (RepeaterItem item in rptRepInfo.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBox fname = (TextBox)item.FindControl("txtFirstName");
                    sqlUpdate.Parameters.AddWithValue("@First_Name", fname.Text);
                    TextBox lname = (TextBox)item.FindControl("txtLastName");
                    sqlUpdate.Parameters.AddWithValue("@Last_Name", lname.Text);
                    TextBox pass = (TextBox)item.FindControl("txtPassword");
                    sqlUpdate.Parameters.AddWithValue("@Password", pass.Text);
                    TextBox backup = (TextBox)item.FindControl("txtBackup");
                    sqlUpdate.Parameters.AddWithValue("@Backup_Email", backup.Text);
                }
            }
            int success = objDB.DoUpdateUsingCmdObj(sqlUpdate);
                if(success < 1)
            {
                lblError.Text = "Error: your information failed to update.";
            }
            else
            {
                lblError.Text = "";
            }
            BindContactInfo();
            BindRepInfo();
        }
    }
}
