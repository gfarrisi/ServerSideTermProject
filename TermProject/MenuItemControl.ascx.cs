﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class MenuItemControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String ItemName
        {
            get { return txtItemName.InnerText; }
            set { txtItemName.InnerText = value; }
        }

        public String ItemDescription
        {
            get { return txtItemDescription.InnerText; }
            set { txtItemDescription.InnerText = value; }
        }

        public String ItemPrice
        {
            get { return txtPrice.InnerText; }
            set { txtPrice.InnerText = value; }
        }

        public String ItemImage
        {
            get { return imgMenuItem.Src; }
            set { imgMenuItem.Src = value; }
        }
    }
}