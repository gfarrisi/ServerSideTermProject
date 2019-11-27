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
            RestaurantID = res.RestaurantID;
            Response.Write(RestaurantID.ToString());
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
                ctrlMIC.ItemName = drvCurrent[2].ToString();
                ctrlMIC.ItemImage = drvCurrent[3].ToString();
                ctrlMIC.ItemDescription = drvCurrent[4].ToString();
                Decimal price = Decimal.Parse(drvCurrent[5].ToString());
                ctrlMIC.ItemPrice = price.ToString("C2");
                if (!drvCurrent[6].ToString().Equals(""))
                {
                    string JSON = drvCurrent[9].ToString();
                    System.Diagnostics.Debug.WriteLine(JSON);
                    //     List<string> dJSON = JsonConvert.DeserializeObject<List<string>>(JSON);
                    //     Response.Write(dJSON.ToString());

                    while (i + 1 < ds.Tables[0].Rows.Count)
                    {
                        if (currentItemID == int.Parse(ds.Tables[0].Rows[i + 1][0].ToString()))
                        {
                            DataRow drvNext = ds.Tables[0].Rows[i + 1];
                            JSON = drvNext[9].ToString();
                            System.Diagnostics.Debug.WriteLine(JSON);

                           // ctrlMIC.ItemConfigurableRepeater.DataBind();
                            i++;
                        }
                    }
                }
                divMenu.Controls.Add(ctrlMIC);
                i++;
            }
        }
    }
}