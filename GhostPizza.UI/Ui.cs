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
        public string Buffer { get; set; } = string.Empty;

        public Ui()
        {
            
        }


        public void Start()
        {
            ExecWhileHandlingError(DisplayLoginRegisterMenu);
        }

        public void ExecWhileHandlingError(Action action)
        {
            bool failed = false;
            do
            {
                try
                {
                    action.Invoke();
                    failed = false;
                }
                catch (Exception e)
                {
                    BufferError(e.Message);
                    failed = true;
                }
            } while (failed);
        }

        public void DisplayLoginRegisterMenu()
        {
            LoginRegisterMenuCommand command = InputHelper.DisplayAndGetCommandBySelection(initialCommands,() => Console.WriteLine(""));
                
            switch (command)
            {
                case LoginRegisterMenuCommand.Login:
                        ExecWhileHandlingError(LoginUser);
                        ExecWhileHandlingError(DisplayUserMenu);
                    break;
                case LoginRegisterMenuCommand.Register:
                        ExecWhileHandlingError(RegisterUser);
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
                        ExecWhileHandlingError(DisplayProductsMenu);
                        break;
                    case UserMenuCommand.Order:
                        Buffer = (prods.Sum(p => p.Amount * p.Price)).ToString();
                        InputHelper.PromptAndGetOrderInfoFromConsole();
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
            InputHelper.DisplayProductsAndGetBasketFromConsole(prods,PrintBuffer,"How many? ");
        }

        private void BufferError(string msg)
        {
            Buffer = string.Empty;
            Buffer = $"(!) {msg}";
        }

        /// <summary>
        /// Prints buffer to the console. Handles coloring (warning, error)
        /// </summary>
        public void PrintBuffer()
        {
            if (Buffer != string.Empty)
            {
                if (Buffer.StartsWith("(!)"))
                    ConsoleHelpers.PrintError($"\n{Buffer}\n");
                else
                    ConsoleHelpers.PrintPositive($"\n{Buffer}\n");
            }
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
