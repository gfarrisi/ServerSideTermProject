using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class ChooseAccountType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbLogin.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF5581");

        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerRegistration.aspx");
        }
    }
}