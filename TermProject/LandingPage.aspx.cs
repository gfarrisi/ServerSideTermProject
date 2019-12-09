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
    public partial class WebForm1 : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCookieData();
            }
            if (!String.IsNullOrEmpty(Request.QueryString["search"]))
            {
                String strName = Request.QueryString["search"];
                return;
            }
            //get dataset from viewstate, if it exists
            ds = (DataSet)ViewState["DataSet"];
            if (ds == null) {
                //retrieve database for the first time
                SqlCommand sqlGetRestaurants = new SqlCommand();
                sqlGetRestaurants.CommandType = CommandType.StoredProcedure;
                sqlGetRestaurants.CommandText = "TP_GetAllRestaurants";
                ds = objDB.GetDataSetUsingCmdObj(sqlGetRestaurants);
                ViewState.Add("DataSet", ds);
            }
           // DrawSearchResults();
        }
        public void GetCookieData()
        {
            HttpCookie cookie = Request.Cookies["VisitorSessionID"];
            if (cookie != null)
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
            else
            {
                Response.Redirect("Default.aspx");
            }

        }
        /* 
        void DrawSearchResults()
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                RestaurantControl ctrl = (RestaurantControl)LoadControl("RestaurantControl.ascx");

                DataRow drv = ds.Tables[0].Rows[i];
                ctrl.ResID = int.Parse(drv[0].ToString());
                System.Diagnostics.Debug.WriteLine(ctrl.ResID.ToString());
                ctrl.ResTitle = drv[1].ToString();
                ctrl.ResAddress = drv[5].ToString();
                ctrl.ResImage = drv[2].ToString();
                //ctrl.DataBind();
                if (i % 2 == 0)
                {
                    divRestaurantColumn.Controls.Add(ctrl);
                }
                else
                {
                    divRestaurantColumn2.Controls.Add(ctrl);
                }
            }
        }*/

        protected void linkBtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewRestaurant.aspx");
        }
    }
}