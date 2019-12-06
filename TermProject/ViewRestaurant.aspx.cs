using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using FoodOrderingUtils;

namespace TermProject
{
    public partial class ViewRestaurant : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        DataSet ds;
        int RestaurantID = 400;
        //will be account object
        Restaurant res = new Restaurant();
        List<string> testConfigurableList = new List<string>
        {
            "Small",
            "Medium",
            "Large",
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            res = (Restaurant)Session["currentRestaurant"];
            if(res == null)
            {
                Response.Write("404: Please go back and select a restaurant.");
                form1.Visible = false;
                return;
            }
            RestaurantID = res.RestaurantID;
            //load in restaurant info
            SqlCommand sqlGetRestaurant = new SqlCommand();
            sqlGetRestaurant.CommandType = CommandType.StoredProcedure;
            sqlGetRestaurant.CommandText = "TP_GetRestaurant";
            sqlGetRestaurant.Parameters.AddWithValue("@RestaurantID", RestaurantID);
            DataSet dsRes = objDB.GetDataSetUsingCmdObj(sqlGetRestaurant);
            DataRow drRes = dsRes.Tables[0].Rows[0];
            txtRestaurantTitle.InnerText = drRes[1].ToString(); //title
            dvImgRes.Attributes["data-setbg"] = drRes[2].ToString(); //image
            txtPhone.InnerText = drRes[3].ToString();
            txtEmail.InnerText = drRes[4].ToString();
            txtAddress.InnerText = drRes[5].ToString();
            txtCity.InnerText = drRes[6].ToString();
            txtState.InnerText = drRes[7].ToString();
            txtZip.InnerText = drRes[8].ToString();
            if (!IsPostBack)
            {
                SqlCommand sqlGetMenu = new SqlCommand();
                sqlGetMenu.CommandType = CommandType.StoredProcedure;
                sqlGetMenu.CommandText = "TP_GetMenuItems";
                sqlGetMenu.Parameters.AddWithValue("@RestaurantID", RestaurantID);
                ds = objDB.GetDataSetUsingCmdObj(sqlGetMenu);
                ViewState.Add("DataSet", ds);
                // repeaterMenu.DataSource = ds;
                // repeaterMenu.DataBind();
            }
            else
            {
                ds = (DataSet)ViewState["DataSet"];
            }
            if (ds != null)
            {
                DrawMenuItems();
            }
            }
        public void DrawMenuItems() {
            int i = 0;
            while (i < ds.Tables[0].Rows.Count)
            {
                MenuItemControl ctrlMIC = (MenuItemControl)LoadControl("MenuItemControl.ascx");
                DataRow drvCurrent = ds.Tables[0].Rows[i];
                int currentItemID = int.Parse(drvCurrent[0].ToString());
                ctrlMIC.ItemID = currentItemID;
                ctrlMIC.ItemName = drvCurrent[2].ToString();
                ctrlMIC.ItemImage = drvCurrent[3].ToString();
                ctrlMIC.ItemDescription = drvCurrent[4].ToString();
                ctrlMIC.RestaurantID = RestaurantID;
                Decimal price = Decimal.Parse(drvCurrent[5].ToString());
                ctrlMIC.ItemPrice = price.ToString("C2");
                //get configurables
                ctrlMIC.GetConfigurables(currentItemID);
                divMenu.Controls.Add(ctrlMIC);
                i++;
            }
        }
    }
}