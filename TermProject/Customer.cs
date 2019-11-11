using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Gabriella Farrisi
//11.11.2019

namespace TermProject
{
    public class Customer
    {
        private string email { get; set; }
        private string password { get; set; }
        private string first_Name { get; set; }
        private string last_Name { get; set; }        
        private string contact_email { get; set; }
        private string delivery_address { get; set; }
        private string delivery_city { get; set; }
        private string delivery_state { get; set; }
        private string delivery_zip { get; set; }
        private string billing_address { get; set; }
        private string billing_city { get; set; }
        private string billing_state { get; set; }
        private string billing_zip { get; set; }


        public Customer()
        {
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }


        public String First_Name
        {
            get { return first_Name; }
            set { first_Name = value; }
        }

        public String Last_Name
        {
            get { return last_Name; }
            set { last_Name = value; }
        }
        public String Delivery_Address
        {
            get { return delivery_address; }
            set { delivery_address = value; }
        }
        public String Contact_Email
        {
            get { return contact_email; }
            set { contact_email = value; }
        }
        public String Delivery_City
        {
            get { return delivery_city; }
            set { delivery_city = value; }
        }
        public String Delivery_State
        {
            get { return delivery_state; }
            set { delivery_state = value; }
        }
        public String Delivery_Zip
        {
            get { return delivery_zip; }
            set { delivery_zip = value; }
        }
        public String Billing_Address
        {
            get { return billing_address; }
            set { billing_address = value; }
        }
        public String Billing_City
        {
            get { return billing_city; }
            set { billing_city = value; }
        }
        public String Billing_State
        {
            get { return billing_state; }
            set { billing_state = value; }
        }
        public String Billing_Zip
        {
            get { return billing_zip; }
            set { billing_zip = value; }
        }
    }
}