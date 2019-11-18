using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class RestaurantControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String ResTitle
        {
            get { return txtRestaurantName.InnerText; }
            set { txtRestaurantName.InnerText = value; }
        }
        public String ResDescription
        {
            get { return txtDescription.InnerText; }
            set { txtDescription.InnerText = value; }
        }

        public String ResAddress
        {
            get { return txtAddress.InnerText; }
            set { txtAddress.InnerText = value; }
        }

        public String ResImage

        {
            get { return imgRestaurant.Src; }
            set { imgRestaurant.Src = value; }
        }
    }
}