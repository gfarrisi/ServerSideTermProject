using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using FoodOrderingUtils;
using Utilities;

namespace TermProject
{
    public partial class AddItem : System.Web.UI.Page
    {
        MenuItem mItem = new MenuItem();
        bool newItem = true;
        DBConnect objDB = new DBConnect();
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["item"] != null)
            {
                mItem = (MenuItem)Session["item"];
                newItem = false;
            }
        }
        protected void btnAddConfigurable_Click(object sender, EventArgs e)
        {
            if (!txtConfigurableName.Text.Equals("") && !txtConfigurableValues.Text.Equals(""))
            {
                configurableWarning.InnerHtml = "";
                MenuConfigurableItem mci = new MenuConfigurableItem();
                mci.Title = txtConfigurableName.Text;
                string valuesList = txtConfigurableValues.Text;
                List<string> splitList = new List<string>(valuesList.Split(new string[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries));
                mci.Values = splitList;
                mci.ValuesList = string.Join(", ", splitList);
                mItem.Configurables.Add(mci);
                gvConfigurables.DataSource = mItem.Configurables;
                gvConfigurables.DataBind();
                Session.Add("item", mItem);
                txtConfigurableName.Text = "";
                txtConfigurableValues.Text = "";
            }
            else
            {
                configurableWarning.InnerHtml = "Please fill out all fields. <br/>";
            }
        }


        protected void btnRemoveConfigurables_Click(object sender, EventArgs e)
        {

            mItem.Configurables = new List<MenuConfigurableItem>();
            gvConfigurables.DataSource = mItem.Configurables;
            gvConfigurables.DataBind();
            Session.Add("item", mItem);
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Session.Remove("item");
            //validate data from form
            string itemName = txtItemName.Text;
            string itemImage = txtItemImg.Text;
            string itemDesc = txtItemDescription.Text;
            float price = float.Parse(txtItemPrice.Text);

            // int restaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
            int restaurantID = 400;
            //create menu item objects

            //FoodOrderingUtils.MenuItem menuItem = new FoodOrderingUtils.MenuItem();
            mItem.Title = itemName;
            mItem.Image = itemImage;
            mItem.Description = itemDesc;
            mItem.Price = price;
            mItem.RestaurantID = restaurantID;
            //add to database
            SqlParameter returnParameter = new SqlParameter();
            SqlCommand sqlAddOrder = new SqlCommand();
            sqlAddOrder.CommandType = CommandType.StoredProcedure;
            if (newItem)
            {
                sqlAddOrder.CommandText = "TP_CreateMenuItem";
                returnParameter = sqlAddOrder.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
            }
            else
            {
                sqlAddOrder.CommandText = "[TP_UpdateMenuItem]";
                sqlAddOrder.Parameters.AddWithValue("@Menu_Item_ID", mItem.ID);
            }
            sqlAddOrder.Parameters.AddWithValue("@Title", mItem.Title);
            sqlAddOrder.Parameters.AddWithValue("@Image", mItem.Image);
            sqlAddOrder.Parameters.AddWithValue("@RestaurantID", mItem.Description);
            sqlAddOrder.Parameters.AddWithValue("@Description", mItem.Description);
            sqlAddOrder.Parameters.AddWithValue("@Price", mItem.Price);
           
            int returnNum = objDB.DoUpdateUsingCmdObj(sqlAddOrder);
            if (returnNum > 0)
            {
                if (newItem)
                {
                    mItem.ID = (int)returnParameter.Value;
                   
                }
                foreach (MenuConfigurableItem mci in mItem.Configurables)
                {
                    if (newItem)
                    {
                        sqlAddOrder.CommandText = "[TP_CreateMenuItemConfigurable]";
                        returnParameter = sqlAddOrder.Parameters.Add("RetVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                    }
                    else
                    {
                        sqlAddOrder.CommandText = "[TP_UpdateMenuItemConfigurable]";
                        sqlAddOrder.Parameters.AddWithValue("@Menu_Item_ID", mItem.ID);
                    }
                    sqlAddOrder.Parameters.AddWithValue("@Title", mItem.Title);
                    sqlAddOrder.Parameters.AddWithValue("@Image", mItem.Image);
                    sqlAddOrder.Parameters.AddWithValue("@RestaurantID", mItem.Description);
                    sqlAddOrder.Parameters.AddWithValue("@Description", mItem.Description);
                    sqlAddOrder.Parameters.AddWithValue("@Price", mItem.Price);

                    int retu = objDB.DoUpdateUsingCmdObj(sqlAddOrder);
                    if (retu > 0)
                    {
                    }
                }


            }


            //redirect to landing page



            Server.Transfer("RestaurantLanding.aspx");
        }

    }
}