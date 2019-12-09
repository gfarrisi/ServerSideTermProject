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
        DataTable dt;
        string searchTerm;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCookieData();
                GetSearchResults();
            }
            else
            {
                searchTerm = txtSearch.Text;
                GetSearchResults();
            }
            ////get dataset from viewstate, if it exists
            //ds = (DataSet)ViewState["DataSet"];
            //if (ds == null) {
            //    //retrieve database for the first time
            //    SqlCommand sqlGetRestaurants = new SqlCommand();
            //    sqlGetRestaurants.CommandType = CommandType.StoredProcedure;
            //    sqlGetRestaurants.CommandText = "TP_GetAllRestaurants";
            //    ds = objDB.GetDataSetUsingCmdObj(sqlGetRestaurants);
            //    ViewState.Add("DataSet", ds);
            //}

        }
        public void GetCookieData()
        {
            HttpCookie cookie = Request.Cookies["VisitorSessionID"];
            if (Session["Email"] == null || Session["AccountType"].ToString() != "Customer")
            {
                Response.Redirect("Default.aspx");
            }
            else if (cookie != null)
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

        }
        void GetSearchResults()
        {
            //get dataset from viewstate, if it exists
            ds = (DataSet)ViewState["DataSet"];
            if (ds == null)
            {
                //retrieve database for the first time
                SqlCommand sqlGetRestaurants = new SqlCommand();
                sqlGetRestaurants.CommandType = CommandType.StoredProcedure;
                sqlGetRestaurants.CommandText = "TP_GetAllRestaurants";
                ds = objDB.GetDataSetUsingCmdObj(sqlGetRestaurants);
                ViewState.Add("DataSet", ds);
            }

            String strName = searchTerm;
            //Response.Write(strName);
            if (ds != null)

                dt = ds.Tables[0];
            if (!String.IsNullOrEmpty(strName))
            {
                dt.DefaultView.RowFilter = "Restaurant_Name Like '%" + strName + "%' OR Restaurant_Category like '%" + strName + "%'";
            }
            if (dt != null)
            {
                DrawSearchResults();
            }
        }

        void DrawSearchResults()
        {
            if (dt.DefaultView.Count > 0)
            {
                int i = 0;
                foreach (DataRow drv in dt.DefaultView.ToTable().Rows)
                {
                    RestaurantControl ctrl = (RestaurantControl)LoadControl("RestaurantControl.ascx");
                    ctrl.ResID = int.Parse(drv[0].ToString());
                    ctrl.ResTitle = drv[1].ToString();
                    ctrl.ResAddress = drv[5].ToString();
                    ctrl.ResImage = drv[2].ToString();
                    ctrl.ResEmail = drv[4].ToString();
                    ctrl.ResCategory = drv[13].ToString();
                    if (i % 2 == 0)
                    {
                        divRestaurantColumn.Controls.Add(ctrl);
                        i++;
                    }
                    else
                    {
                        divRestaurantColumn2.Controls.Add(ctrl);
                        i++;
                    }
                }
            }
        }


            protected void linkBtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewRestaurant.aspx");
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //string oldsearch = txtSearch.Text;
            //TextBox search = (TextBox)sender;
            
            //if (searchTerm != oldsearch)
            //{
            //    GetSearchResults();
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}