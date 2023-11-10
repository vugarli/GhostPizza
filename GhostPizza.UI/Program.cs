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
            User admin = new("admin","admin","admin","admin");
            admin.UserType = UserType.Admin;

            User regular = new("reg","reg","reg","reg");
            UserService.AddUser(admin);
            UserService.AddUser(regular);

            Pizza pizza1 = new Pizza("Gobelekli",10.3m);
            Pizza pizza2 = new Pizza("Salamili",14.3m);
            Pizza pizza3 = new Pizza("Pepperoni",9.3m);

            PizzaService.AddPizza(pizza1);
            PizzaService.AddPizza(pizza2);
            PizzaService.AddPizza(pizza3);

            Ui ui = new Ui();
            ui.Start();
        }
    }
}
