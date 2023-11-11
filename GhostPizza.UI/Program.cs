using GhostPizza.Core.Models;
using GhostPizza.InfraStructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.UI
{
    internal class Program
    {
        static void Main()
        {
            //Seeding

            User admin = new("admin","admin","admin","admin");
            admin.UserType = UserType.Admin;
            UserService.AddUser(admin);
            UserService.AddUser(new("reg", "reg", "reg", "reg"));

            PizzaService.AddPizza(new("Gobelekli", 10.3m));
            PizzaService.AddPizza(new("Salamili", 14.3m));
            PizzaService.AddPizza(new("Pepperoni", 9.3m));
            PizzaService.AddPizza(new("Qarisiq",14.56m));
            PizzaService.AddPizza(new("Meksika acili",4.99m));
            PizzaService.AddPizza(new("Ananasli",3.99m));
            PizzaService.AddPizza(new("Special Ghost Pizza",20.99m));

            Ui ui = new Ui();
            ui.Start();
        }
    }
}
