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
using System.Net;
using System.IO;

namespace TermProject
{
    public partial class ViewAllTransactions : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCookieData();
                GetTransactions();
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
        public void GetTransactions()
        {
            //take from session
            string VirtualWalletID = Session["Email"].ToString();
            //string email = "gabriellafarrisi@gmail.com";

            //get api key info
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAPIKey";
            objCommand.Parameters.Clear();

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];

            string APIKey = myDT.Rows[0]["API_Key"].ToString();
            string MerchantID = myDT.Rows[0]["ID"].ToString();

            //call api
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            String webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug35007/WebAPI/api/service/paymentgateway/GetTransactions/";

            WebRequest request = WebRequest.Create(webApiUrl + APIKey + "/" + MerchantID + "/" + VirtualWalletID);
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            //// Deserialize a JSON string into a Team object.
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Team team = js.Deserialize<Team>(data);
            List<Transaction> transactions = new List<Transaction>();
            //set balance
            if (data != "")
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                transactions = js.Deserialize<List<Transaction>>(Server.UrlDecode(data));
                gvTransactions.DataSource = transactions;
                gvTransactions.DataBind();
                //List<Transaction> = data.ToList;
            }
            else
            {
                //lblErrorDisplay.Text = "No balance found for this account!";
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
    }
}