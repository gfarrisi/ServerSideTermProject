using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingUtils
{

    public class Order
    {
        public int OrderID { get; set; }
        public string OrderStatus { get; set; }
        public Decimal OrderTotalCost { get; set; }
        public int OrderRestaurant { get; set; }
        public List<OrderItem> OrderItemList {
            get;
            set;
        }

        public Order()
        {
            OrderItemList = new List<OrderItem>();
        }


    }
    
}
