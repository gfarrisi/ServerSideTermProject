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
using FoodOrderingUtils;

namespace TermProject
{
    public partial class UserAccountSettings : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        // string restaurantRepEmail = Session["userEmail"].ToString();
        Restaurant res;
        
        //string userEmail = "gabriellafarrisi@gmail.com";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCookieData();
                res = (Restaurant)Session["User"];
                BindUserInfo();
            }
        }

        public void GetCookieData()
        {
            HttpCookie cookie = Request.Cookies["VisitorSessionID"];
            if (Session["Email"] == null || Session["AccountType"].ToString() != "Customer")
            {
                Response.Redirect("Default.aspx");
            }
            else if (cookie != null)
            {
                string email = cookie.Value.ToString();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetUser";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@Email", email);

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable myDT = myDS.Tables[0];

                string type = myDT.Rows[0]["Account_Type"].ToString();
                Session["Email"] = email;
                Session["AccountType"] = type;
            }
        }
        public void BindUserInfo()
        {
            string userEmail = Session["Email"].ToString();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetUser";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@Email", userEmail);

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
              
        protected void lbAccountSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserAccountSettings.aspx");
        }

        protected void lbPaymentInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentInfo.aspx");
        }

        protected void lbCurrentOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderStatus.aspx");
        }
        protected void lbTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllTransactions.aspx");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string userEmail = Session["Email"].ToString();

            foreach (RepeaterItem item in rptRepInfo.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    SqlCommand sqlUpdate = new SqlCommand();
                    sqlUpdate.CommandType = CommandType.StoredProcedure;
                    sqlUpdate.CommandText = "TP_UpdateCustomerInfo";
                    TextBox fname = (TextBox)item.FindControl("txtFirstName");
                    sqlUpdate.Parameters.AddWithValue("@Email", userEmail);
                    sqlUpdate.Parameters.AddWithValue("@First_Name", fname.Text);
                    TextBox lname = (TextBox)item.FindControl("txtLastName");
                    sqlUpdate.Parameters.AddWithValue("@Last_Name", lname.Text);
                    TextBox pass = (TextBox)item.FindControl("txtPassword");
                    sqlUpdate.Parameters.AddWithValue("@Password", pass.Text);
                    TextBox backup = (TextBox)item.FindControl("txtBackupEmail");
                    sqlUpdate.Parameters.AddWithValue("@Backup_Email", backup.Text);
                    TextBox daddress = (TextBox)item.FindControl("txtDeliveryAddress");
                    sqlUpdate.Parameters.AddWithValue("@Delivery_Address", daddress.Text);
                    TextBox dcity = (TextBox)item.FindControl("txtDeliveryCity");
                    sqlUpdate.Parameters.AddWithValue("@Delivery_City", dcity.Text);
                    DropDownList dstate = (DropDownList)item.FindControl("txtDeliveryState");
                    sqlUpdate.Parameters.AddWithValue("@Delivery_State", dstate.SelectedValue);
                    TextBox dzip = (TextBox)item.FindControl("txtDeliveryZip");
                    sqlUpdate.Parameters.AddWithValue("@Delivery_Zip", dzip.Text);
                    TextBox baddress = (TextBox)item.FindControl("txtBillingAddress");
                    sqlUpdate.Parameters.AddWithValue("@Billing_Address", baddress.Text);
                    TextBox bcity = (TextBox)item.FindControl("txtBillingCity");
                    sqlUpdate.Parameters.AddWithValue("@Billing_City", bcity.Text);
                    DropDownList bstate = (DropDownList)item.FindControl("txtBillingState");
                    sqlUpdate.Parameters.AddWithValue("@Billing_State", bstate.SelectedValue);
                    TextBox bzip = (TextBox)item.FindControl("txtBillingZip");
                    sqlUpdate.Parameters.AddWithValue("@Billing_Zip", bzip.Text);
                    int success = objDB.DoUpdateUsingCmdObj(sqlUpdate);
                    if (success < 1)
                    {
                        lblError.Visible = true;
                        lblError.Text = "Error: your information failed to update.";
                    }
                    else
                    {
                        if (chkDeleteCookie.Checked)
                        {
                            HttpCookie cookie = Request.Cookies["VisitorSessionID"];

                            if (cookie != null)
                            {
                                Response.Cookies.Remove("VisitorSessionID");
                                cookie.Value = null;
                                cookie.Values["Email"] = null;
                                cookie.Expires = DateTime.Now.AddDays(-30);
                                Response.SetCookie(cookie);
                            }
                        }

                        lblError.Visible = true;
                        lblError.Text = "Your account was successfully updated.";
                    }
                  
                }
            }
            BindUserInfo();
        }
    }
}