using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class AddItem : System.Web.UI.Page
    {
        int numControls; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAddConfigurable_Click(object sender, EventArgs e)
        {

        }


        protected void btnRemoveConfigurables_Click(object sender, EventArgs e)
        {
            numControls = 0;
            panelConfigure.ContentTemplateContainer.Controls.Clear();

        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

    }
}