using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.Core.Models
{
    public class Basket
    {
        public List<BasketElement> Products { get; set; } = new List<BasketElement>();
        
        public void ClearBasket()
        {
            Products.Clear();
        }
    }
}
