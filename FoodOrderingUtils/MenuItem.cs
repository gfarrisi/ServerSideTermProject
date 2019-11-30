using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingUtils
{
    public class MenuItem
    {
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<MenuConfigurableItem> Configurables
        {
            get;
            set;
        }

        public MenuItem()
        {
            Configurables = new List<MenuConfigurableItem>();
        }
    }
}
