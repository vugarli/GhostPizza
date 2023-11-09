using GhostPizza.UI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GhostPizza.UI
{
    internal class Ui
    {
        LoginRegisterMenuCommand[] initialCommands = 
            new LoginRegisterMenuCommand[]
            {
                LoginRegisterMenuCommand.Login,
                LoginRegisterMenuCommand.Register
            };

        UserMenuCommand[] userMenuCommands =
            new UserMenuCommand[]
            {
                UserMenuCommand.Show_All_Pizzas,
                UserMenuCommand.Order,
                UserMenuCommand.CRUD_Pizza,
                UserMenuCommand.CRUD_User
            };

        public string[] prods = new[]
        {
            "Gobelekli",
            "Pendirli",
            "Salami"
        };

        public Ui()
        {
            
        }


        public void Start()
        {

            DisplayLoginRegisterMenu();

        }

        public void DisplayLoginRegisterMenu()
        {

            var command = InputHelper.DisplayAndGetCommandBySelection(initialCommands,() => Console.WriteLine(""));
            switch (command)
            {
                case LoginRegisterMenuCommand.Login:
                    break;
                case LoginRegisterMenuCommand.Register:
                    break;
            }

        }

        public void DisplayProductsMenu()
        {
            var element = InputHelper.DisplayAndGetElementBySelection(prods, () => Console.WriteLine());
        }
        
        public void LoginUser()
        {

        }

        public void RegisterUser()
        {

        }

    }
}
