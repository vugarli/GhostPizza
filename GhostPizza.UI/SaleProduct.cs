using GhostPizza.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.UI
{
    internal class SaleProduct
    {
        public Pizza Pizza { get; set; }
        public bool IsAddedToBasket { get; set; } = false;
        public int AmountInBasket { get; set; }
        
        public SaleProduct(Pizza product)
        {
            Pizza = product;
        }
        public override string ToString()
        {
            return $" {Pizza.Id} {Pizza.Name} {Pizza.Price}$ ";
        }
    }

}
