using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateLinkColors();
        }


        public void UpdateLinkColors()
        {
            lbCreateAccount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF5581");
            lbForgotEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF5581");
            lbForgotPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF5581");
            //#FF5581
        }

        protected void lbForgotEmail_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotEmail.aspx");
        }
        protected void lbForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
        protected void lbCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChooseAccountType.aspx");
        }
    }
}