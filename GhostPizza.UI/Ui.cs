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
                UserMenuCommand.CRUD_User,
                UserMenuCommand.Quit
            };

        public InputProduct[] prods = new InputProduct[]
        {
            new(0,"Pizza1",5.00m),
            new(1,"Pizza2",3.00m),
            new(2,"Pizza3",2.00m),
        };

        public Ui()
        {
            
        }


        public void Start()
        {

            //DisplayLoginRegisterMenu();
            DisplayUserMenu();
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

        public void DisplayUserMenu()
        {
            UserMenuCommand command;
            do
            {
                command = InputHelper.DisplayAndGetCommandBySelection(userMenuCommands, PrintBuffer);

                switch (command)
                {
                    case UserMenuCommand.Show_All_Pizzas:
                        DisplayProductsMenu();
                        break;
                    case UserMenuCommand.Order:
                        Buffer = (prods.Sum(p => p.Amount * p.Price)).ToString();
                        break;
                    case UserMenuCommand.CRUD_Pizza:
                        break;
                    case UserMenuCommand.CRUD_User:
                        break;
                }
            } while (command != UserMenuCommand.Quit);
        }

        public void DisplayProductsMenu()
        {
            here:
            try
            {
                InputHelper.DisplayProductsAndGetBasketFromConsole(prods,PrintBuffer,"How many? ");
            }
            catch (Exception ex) 
            {
                Buffer = ex.Message;
                goto here;
            }
        }

        public string Buffer { get; set; }
        public void PrintBuffer()
        {
            Console.WriteLine(Buffer);
            Buffer = string.Empty;
        }

        public void LoginUser()
        {

        }

        public void RegisterUser()
        {

        }

    }
}
