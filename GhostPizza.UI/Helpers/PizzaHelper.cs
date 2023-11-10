using GhostPizza.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.UI.Helpers
{
    internal static class PizzaHelper
    {

        public static (string name, decimal price) GetPizzaInfoFromConsole()
        {
            var name = InputHelper.PromptAndTryGetNonEmptyString("Pizza name: ");
            var price = InputHelper.PromptAndGetPositiveDecimal("Pizza price: ");
            
            return (name, price);
        }

        public static void UpdatePizzaFromConsole(Pizza pizzaToUpdate)
        {
            var id = InputHelper.DisplayAndGetElementBySelection(new List<string>(){"Name","Price"},"Choose prop to update");
            switch(id)
            {
                case 0:
                    pizzaToUpdate.Name = InputHelper.PromptAndTryGetNonEmptyString("Pizza name: ");
                    break;
                case 1:
                    pizzaToUpdate.Price = InputHelper.PromptAndGetPositiveDecimal("Pizza price: ");
                    break;
            }
        }


    }

}
