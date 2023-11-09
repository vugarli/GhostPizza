using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.Core.Models
{
    public record BasketElement
    {
        public int PizzaId { get; init; }
        public int Count { get; init; }

        public BasketElement(int pizzaId, int count)
        {
            PizzaId = pizzaId;
            Count = count;
        }
    }
}
