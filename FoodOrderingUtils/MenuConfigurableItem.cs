using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingUtils
{
    public class MenuConfigurableItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<string> Values { get; set; }

        public MenuConfigurableItem()
        {

        }
    }
}
