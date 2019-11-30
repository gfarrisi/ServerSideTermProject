using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using FoodOrderingUtils;

namespace TermProject
{
    public partial class AddItem : System.Web.UI.Page
    {
        MenuItem mItem = new MenuItem();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["item"] != null)
            {
                mItem = (MenuItem)Session["item"];
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
            Server.Transfer("ManageRestaurant.aspx");
        }

    }
}