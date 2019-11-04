using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingUtils
{
    public class RepresentativeAccount
    {
        int RestaurantID { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string RepresentativeName { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
    }
}
