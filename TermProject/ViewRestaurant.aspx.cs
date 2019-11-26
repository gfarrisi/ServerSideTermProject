using Newtonsoft.Json;
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
    public partial class ViewRestaurant : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        DataSet ds;
        int RestaurantID = 400;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlCommand sqlGetMenu = new SqlCommand();
                sqlGetMenu.CommandType = CommandType.StoredProcedure;
                sqlGetMenu.CommandText = "TP_GetMenuItems";
                sqlGetMenu.Parameters.AddWithValue("@RestaurantID", RestaurantID);
                ds = objDB.GetDataSetUsingCmdObj(sqlGetMenu);
                // repeaterMenu.DataSource = ds;
                // repeaterMenu.DataBind();
                int i = 0; 
                while (i < ds.Tables[0].Rows.Count)
                {
                    MenuItemControl ctrlMIC = (MenuItemControl)LoadControl("MenuItemControl.ascx");
                    DataRow drvCurrent = ds.Tables[0].Rows[i];
                    int currentItemID = int.Parse(drvCurrent[0].ToString());
                    ctrlMIC.ItemName = drvCurrent[2].ToString();
                    ctrlMIC.ItemImage = drvCurrent[3].ToString();
                    ctrlMIC.ItemDescription = drvCurrent[4].ToString();
                    ctrlMIC.ItemPrice = drvCurrent[6].ToString();
                    if (!drvCurrent[6].ToString().Equals(""))
                    {
                        string JSON = drvCurrent[9].ToString();
                        System.Diagnostics.Debug.WriteLine(JSON);
                   //     List<string> dJSON = JsonConvert.DeserializeObject<List<string>>(JSON);
                   //     Response.Write(dJSON.ToString());

                        while (currentItemID == int.Parse(ds.Tables[0].Rows[i + 1][0].ToString()))
                        {
                        }
                    }
                    i++;
                }

            }
        }
    }
}