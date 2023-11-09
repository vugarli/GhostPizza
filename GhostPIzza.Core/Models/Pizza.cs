using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.Core.Models
{
    public class Pizza
    {
        private static int _idCounter = 1;

        public int Id { get; private set; } = _idCounter++;
        public string Name { get; private set; }
        public List<BasketElement> Products { get; set; } = new List<BasketElement>();

        public Pizza(string name)
        {
            Name = name;
        }
    }
}
