using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.Core.Models
{
    public class Pizza
    {
        private static int _idCounter = 1;

        public int Id { get; private set; } = _idCounter++;
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Pizza(string name, decimal price)
        {
            Name = name;
            Price = price; 
        }
        public override string ToString()
        {
            return $" {Id} {Name} {Price}$ ";
        }

    }
}
