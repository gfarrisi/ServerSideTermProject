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
//using FoodOrderingUtils;

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
                GetCookieData();
                UpdateLinkColors();
                BindContactInfo();
                GetMenuItmes();             
            }

        }
        public void GetCookieData()
        {
            HttpCookie cookie = Request.Cookies["VisitorSessionID"];
            if (Session["Email"] == null || Session["AccountType"].ToString() != "Rep")
            {
                Response.Redirect("Default.aspx");
            }
            else if (cookie != null)
            {
                string restaurantRepEmail = cookie.Value.ToString();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetUser";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@Email", restaurantRepEmail);

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable myDT = myDS.Tables[0];

                string type = myDT.Rows[0]["Account_Type"].ToString();
                Session["Email"] = restaurantRepEmail;
                Session["AccountType"] = type;


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetRestaurantFromRep";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@Representative_Email", restaurantRepEmail);

                myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                myDT = myDS.Tables[0];

                int restaurantID = Convert.ToInt32(myDT.Rows[0]["Restaurant_ID"].ToString());
                Session["RestaurantID"] = restaurantID;
            }

        }

        public void UpdateLinkColors()
        {
            lbAccountSettings.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
            lbMenuManagement.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
            lbCurrentOrders.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");        
        }
        public void BindContactInfo()
        {
            int restaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
            //int restaurantID = 400;

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
            int restaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
            //int restaurantID = 400;

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

        protected void btnAddMenuItem_Click(object sender, EventArgs e)
        {
            if (Session["item"] != null)
            {
                Session.Remove("item");
            }
            Response.Redirect("AddItem.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //TP_DeleteMenuItem
          
            //@OrderItemID
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
       
        protected void rptMenuItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeleteItem")
            {
                HiddenField hfID = (HiddenField)e.Item.FindControl("hfMenuItemID");
                int itemID = Convert.ToInt32(hfID.Value);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_DeleteMenuItem";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@MenuItemID", itemID);
                int result = objDB.DoUpdateUsingCmdObj(objCommand);
                if (result > 0)
                {
                    GetMenuItmes();
                }
            }
            else if (e.CommandName == "EditItem")
            {
                int restaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
                //int restaurantID = 400;
                HiddenField hfID = (HiddenField)e.Item.FindControl("hfMenuItemID");
                int itemID = Convert.ToInt32(hfID.Value);
                Image img = (Image)e.Item.FindControl("imgMenuItem");
                string imgUrl = img.ImageUrl;
                Label lbTitle = (Label)e.Item.FindControl("lblTitle");
                string title = lbTitle.Text;
                Label lblDescription = (Label)e.Item.FindControl("lblDescription");
                string description = lblDescription.Text;
                Label lblPrice = (Label)e.Item.FindControl("lblPrice");
                string price = lblPrice.Text;
                Label lblCategory = (Label)e.Item.FindControl("lblCategory");
                string category = lblCategory.Text;

                FoodOrderingUtils.MenuItem menuItem = new FoodOrderingUtils.MenuItem();
                menuItem.ID = Convert.ToInt32(hfID.Value);
                menuItem.RestaurantID = restaurantID;
                menuItem.Image = imgUrl;
                menuItem.Title = title;
                menuItem.Description = description;
                menuItem.Price = Single.Parse(price, System.Globalization.NumberStyles.Currency);
                menuItem.Category = category;

                List<FoodOrderingUtils.MenuConfigurableItem> configvalues = new List<FoodOrderingUtils.MenuConfigurableItem>();
                Repeater rptConf = (Repeater)e.Item.FindControl("rptItemConfigurableTitle");
                foreach (RepeaterItem item in rptConf.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        FoodOrderingUtils.MenuConfigurableItem mic = new FoodOrderingUtils.MenuConfigurableItem();
                        Label lblItemConfigurableTitle = (Label)item.FindControl("lblItemConfigurableTitle");
                        string itemConfigurableTitle = lblItemConfigurableTitle.Text;


                        List<string> values = new List<string>();
                        Repeater rptConfValues = (Repeater)item.FindControl("rptItemConfigurables");
                        foreach (RepeaterItem ri in rptConfValues.Items)
                        {
                            if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                            {                               
                                Label lblItemConfigurables = (Label)ri.FindControl("lblItemConfigurables");
                                string itemConfigurableValues = lblItemConfigurables.Text;
                                values.Add(itemConfigurableValues);
                            }
                        }

                        mic.Title = itemConfigurableTitle;
                        mic.Values = values;
                        configvalues.Add(mic);
                    }
                }
                menuItem.Configurables = configvalues;
                Session.Add("item", menuItem);
                Response.Redirect("AddItem.aspx");
            }
        }
    }
}