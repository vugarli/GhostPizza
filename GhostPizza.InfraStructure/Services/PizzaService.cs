using GhostPizza.Core.Models;
using GhostPizza.InfraStructure.Exceptions;

namespace GhostPizza.InfraStructure.Services
{
	internal static class PizzaService
	{
		public static void AddPizza(Pizza pizza)
		{
			DataBase.Pizzas.Add(pizza);
			Console.WriteLine("Pizza added.");
		}

		public static void RemovePizza(int id)
		{
			var pizzaToRemove = DataBase.Pizzas.Find(pizza => pizza.Id == id);
			if (pizzaToRemove != null)
			{
				DataBase.Pizzas.Remove(pizzaToRemove);
				Console.WriteLine("Pizza removed.");
			}
			else
			{
				throw new PizzaNotFoundException("Pizza not found.");
			}
		}

		public static void UpdatePizzaName(int id, string newName)
		{
			var existingPizza = DataBase.Pizzas.Find(pizza => pizza.Id == id);

			if (existingPizza != null)
			{
				existingPizza.Name = newName;

				Console.WriteLine("Pizza name updated.");
			}
			else
			{
				throw new PizzaNotFoundException("Pizza not found.");
			}
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

		public static void GetAllPizzas()
		{
			foreach (var pizza in DataBase.Pizzas)
			{
				Console.WriteLine($"ID: {pizza.Id}, Name: {pizza.Name}");
			}
		}
	}
}
