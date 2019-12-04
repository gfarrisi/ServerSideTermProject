using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Hazel Boston 11-11-2019

namespace FoodOrderingUtils
{
    public class Restaurant 
    {
        public int RestaurantID { get; set; } //0 (column in database table)
        public string RestaurantName { get; set; } //1
        public string ImageURL { get; set; } //2
        public string Phone { get; set; } //3
        public string Email { get; set; } //4
        public string Address { get; set; } //5
        public string City { get; set; } //6
        public string State { get; set; } //7
        public string Zip { get; set; } //8
        public string RepresentativeEmailID { get; set; } //9
        public string PaymentAccountType { get; set; } //10
        public int PaymentAccountNumber { get; set; } //11

        public Restaurant()
        {

        }

        public Restaurant(int id)
        {
            this.RestaurantID = id;
        }
    }
}
