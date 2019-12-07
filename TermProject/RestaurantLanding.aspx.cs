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

        }
        public void BindContactInfo()
        {
            // int restaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
            int restaurantID = 400;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRestaurant";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@RestaurantID", restaurantID);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            rptContactInfo.DataSource = myDT;
            rptContactInfo.DataBind();

            divHero.Attributes["data-setbg"] = myDT.Rows[0]["Image_URL"].ToString(); //image
            MenuTitle.InnerText = myDT.Rows[0]["Restaurant_Name"].ToString() + " - Menu"; 
        }

        public void GetMenuItmes()
        {
            // int restaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
            int restaurantID = 400;

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

            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField field = args.Item.FindControl("hfMenuItemID") as HiddenField;
                int menuItemID = Convert.ToInt32(field.Value);
                             
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_Get_Menu_Item_Configurable";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@Menu_Item_ID", menuItemID);

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable myDT = myDS.Tables[0];
                Repeater rptItemConfigurableTitle = (Repeater)args.Item.FindControl("rptItemConfigurableTitle");
                rptItemConfigurableTitle.DataSource = myDT;
                rptItemConfigurableTitle.DataBind();
                
                               
            }
        }

        protected void ItemBoundConfig(object sender, RepeaterItemEventArgs args)
        {
            List<string> values = new List<string>();


            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField field = args.Item.FindControl("hfMenuItemIDConf") as HiddenField;
                int menuItemConfigID = Convert.ToInt32(field.Value);
                                
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_Get_Menu_Item_Configurable_With_ConfigID";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@Configurable_ID", menuItemConfigID);

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable myDT = myDS.Tables[0];

                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = myDT.Rows[0]["Configurable_Values"].ToString();
           
                values = js.Deserialize<List<string>>(Server.UrlDecode(json));

                Repeater configurablesRepeater = (Repeater)args.Item.FindControl("rptItemConfigurables");
                configurablesRepeater.DataSource = values;
                configurablesRepeater.DataBind();
                

            }
        }
        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {

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
    }
}