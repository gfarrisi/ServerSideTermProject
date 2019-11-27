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
        public int RestaurantID { get; set; }
        string RestaurantName { get; set; }
        string ImageURL { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string RepresentativeEmailID { get; set; }

        public Restaurant()
        {

        }

        public Restaurant(int id)
        {
            this.RestaurantID = id;
        }
    }
}
