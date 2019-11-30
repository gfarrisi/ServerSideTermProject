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

namespace TermProject
{
    public partial class RestaurantLanding : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            //get restaurant rep email from session

            if (!IsPostBack)
            {
                UpdateLinkColors();
                BindContactInfo();
                GetMenuItmes();
            }

        }


        public void UpdateLinkColors()
        {
            lbAccountSettings.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
            lbMenuManagement.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
            lbCurrentOrders.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
            lbViewAsUser.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");


            //lbPhoneNumber.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
            //lbEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
            //lbAddress.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
            //lbCityStateZip.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
            //#FF5581
        }
        public void BindContactInfo()
        {
            //get restaurant rep email from session
            string restaurantRepEmail = "janebackup@gmail.com";

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRestaurantFromRep";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@Representative_Email", restaurantRepEmail);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            rptContactInfo.DataSource = myDT;
            rptContactInfo.DataBind();
        }

        public void GetMenuItmes()
        {

        }
    }
}