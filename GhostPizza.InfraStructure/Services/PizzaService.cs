using GhostPizza.Core.Models;
using GhostPizza.InfraStructure.Exceptions;

namespace GhostPizza.InfraStructure.Services
{
	internal static class PizzaService
	{
		public static void AddPizza(Pizza pizza)
		{
			DataBase.Pizzas.Add(pizza);
		}

		public static void RemovePizza(int id)
		{
			DataBase.Pizzas.Remove(GetPizzaById(id));
		}

		public static void UpdatePizzaName(int id, string newName)
		{
			GetPizzaById(id).Name = newName;
		}

		public static Pizza GetPizzaById(int id)
		{
			var pizza = DataBase.Pizzas.Find(pizza => pizza.Id == id);
			if (pizza != null)
			{
				return pizza;
			}
			else
			{
				throw new PizzaNotFoundException("Pizza not found.");
			}
		}

		public static List<Pizza> GetAllPizzas()
		{
			return DataBase.Pizzas;
		}
	}
}
