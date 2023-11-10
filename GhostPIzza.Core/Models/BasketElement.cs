using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.Core.Models
{
    public record BasketElement
    {
        public Pizza Pizza { get; init; }
        public int Count { get; init; }

        public BasketElement(Pizza product, int count)
        {
            Pizza = product;
            Count = count;
        }
    }
}
