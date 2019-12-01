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
            // int restaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
            int restaurantID = 401;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetMenuItems";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@RestaurantID", restaurantID);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            rptMenuItems.DataSource = myDT;
            rptMenuItems.DataBind();
        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            List<string> values = new List<string>();
           

            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField field = args.Item.FindControl("hfMenuItemID") as HiddenField;
                int menuItemID = Convert.ToInt32(field.Value);
             
                JavaScriptSerializer js = new JavaScriptSerializer();

                List<string> deserializedValue = new List<string>();
                deserializedValue.Add("Small");
                deserializedValue.Add("Medium");
                deserializedValue.Add("Large");
                string json = JsonConvert.SerializeObject(deserializedValue, Formatting.Indented);
                
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_Get_Menu_Item_Configurable";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@Menu_Item_ID", menuItemID);

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable myDT = myDS.Tables[0];
                Repeater rptItemConfigurableTitle = (Repeater)args.Item.FindControl("rptItemConfigurableTitle");
                rptItemConfigurableTitle.DataSource = myDT;
                rptItemConfigurableTitle.DataBind();

                // string json = myDT.Rows[0]["Configurable_Values"].ToString();
                //   string JSON = "[{\"Small\"},{\"Medium\"}, {\"Large\"}]";


                values =js.Deserialize<List<string>>(Server.UrlDecode(json));
                            
                Repeater configurablesRepeater = (Repeater)args.Item.FindControl("rptItemConfigurables");
                configurablesRepeater.DataSource = values;
                configurablesRepeater.DataBind();
                               
            }
        }
    }
}