using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.UI
{
    internal class InputProduct
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; set; }
        public bool IsAddedToBasket { get; set; } = false;

        public int Amount { get; set; }
        
        public InputProduct(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $" {Id} {Name} {Price}$";
        }
    }

}
