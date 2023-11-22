using GhostPizza.Core.Models;
using GhostPizza.InfraStructure;
using GhostPizza.InfraStructure.Exceptions;
using GhostPizza.InfraStructure.Services;
using GhostPizza.UI.Extensions;
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
                UserMenuCommand.Quit
            };
        UserMenuCommand[] adminUserMenuCommands =
            new UserMenuCommand[]
            {
                UserMenuCommand.Show_All_Pizzas,
                UserMenuCommand.Order,
                UserMenuCommand.CRUD_Pizza,
                UserMenuCommand.CRUD_User,
                UserMenuCommand.Quit
            };


        PizzaCrudCommand[] pizzaCrudCommands =
            new PizzaCrudCommand[]
            {
                PizzaCrudCommand.Show_All,
                PizzaCrudCommand.Add,
                PizzaCrudCommand.Update,
                PizzaCrudCommand.Remove,
                PizzaCrudCommand.Quit
            };
        UserCrudCommand[] userCrudCommands =
            new UserCrudCommand[]
            {
                UserCrudCommand.Show_All,
                UserCrudCommand.Add,
                UserCrudCommand.Swap_Role,
                UserCrudCommand.Remove,
                UserCrudCommand.Quit
            };
        public List<SaleProduct> SaleProds { get; set; } = DataBase.Pizzas.Select(p => new SaleProduct(p)).ToList();

        public Ui()
        {
            
        }

        public User LoggedInUser { get; set; } = null;

        public void Start()
        {
            while (true) 
            {
                while (LoggedInUser == null)
                {
                    ConsoleHelpers.ExecWhileHandlingError(DisplayLoginRegisterMenu);
                }
                ConsoleHelpers.ExecWhileHandlingError(DisplayUserMenu);
                LoggedInUser = null;
            }

        }

        public void DisplayLoginRegisterMenu()
        {
            LoginRegisterMenuCommand command = InputHelper.DisplayAndGetCommandBySelection(initialCommands,ConsoleHelpers.Splash);
                
            switch (command)
            {
                case LoginRegisterMenuCommand.Login:
                        LoginUser();
                    break;
                case LoginRegisterMenuCommand.Register:
                        RegisterUser();
                    break;
            }
        }

        public void DisplayUserMenu()
        {
            UserMenuCommand command;
            do
            {
                command = InputHelper.DisplayAndGetCommandBySelection(LoggedInUser.UserType == UserType.Admin ? adminUserMenuCommands : userMenuCommands);

                switch (command)
                {
                    case UserMenuCommand.Show_All_Pizzas:
                        ConsoleHelpers.ExecWhileHandlingError(DisplayProductsMenu);
                        break;
                    case UserMenuCommand.Order:
                        (string mobileNumber,string address) = InputHelper.PromptAndGetOrderInfoFromConsole();
                        ConsoleHelpers.PrintInvoice(LoggedInUser, address, mobileNumber);
                        LoggedInUser.Basket.ClearBasket();
                        SaleProds = DataBase.Pizzas.Select(p => new SaleProduct(p)).ToList();
                        break;
                    case UserMenuCommand.CRUD_Pizza:
                        ConsoleHelpers.ExecWhileHandlingError(DisplayPizzaCrud);
                        break;
                    case UserMenuCommand.CRUD_User:
                        DisplayUserCrud();
                        break;
                }
            } while (command != UserMenuCommand.Quit);
        }

        public void DisplayPizzaCrud()
        {
            PizzaCrudCommand command;
            do
            {
                command = InputHelper.DisplayAndGetCommandBySelection(pizzaCrudCommands);

                switch (command)
                {
                    case PizzaCrudCommand.Show_All:
                        ConsoleHelpers.AddListToBuffer(DataBase.Pizzas);
                        break;
                    case PizzaCrudCommand.Add:
                        (string name, decimal price) = PizzaHelper.GetPizzaInfoFromConsole();
                        var pizza = new Pizza(name, price);
                        PizzaService.AddPizza(pizza);
                        SaleProds.Add(new(pizza));
                        ConsoleHelpers.Buffer = "Added new pizza!";
                        break;
                    case PizzaCrudCommand.Update:
                        var idToUpdate = InputHelper.DisplayAndGetElementBySelection(DataBase.Pizzas, "Choose pizza to update");
                        PizzaHelper.UpdatePizzaFromConsole(DataBase.Pizzas[idToUpdate]);
                        break;
                    case PizzaCrudCommand.Remove:
                        var idToRemove = InputHelper.DisplayAndGetElementBySelection(DataBase.Pizzas,"Remove pizza");
                        PizzaService.RemovePizza(DataBase.Pizzas[idToRemove].Id);
                        SaleProds.RemoveAll(p => p.Pizza.Id == DataBase.Pizzas[idToRemove].Id);
                        ConsoleHelpers.BufferError("Removed pizza!");
                        break;
                }
            } while (command != PizzaCrudCommand.Quit);
        }

        public void DisplayUserCrud()
        {
            UserCrudCommand command;
            do
            {
                command = InputHelper.DisplayAndGetCommandBySelection(userCrudCommands);

                switch (command)
                {
                    case UserCrudCommand.Show_All:
                        ConsoleHelpers.AddListToBuffer(DataBase.Users);
                        break;
                    case UserCrudCommand.Add:
                        var userDetails = UserHelper.GetUserDetails();
                        UserService.AddUser(userDetails.ToUser());
                        ConsoleHelpers.Buffer = "Added new user!";
                        break;
                    case UserCrudCommand.Swap_Role:
                        var idToUpdate = InputHelper.DisplayAndGetElementBySelection(DataBase.Users, "Choose user to swap role");
                        if (DataBase.Users[idToUpdate].UserType == UserType.Admin)
                            DataBase.Users[idToUpdate].UserType = UserType.RegularUser;
                        else
                            DataBase.Users[idToUpdate].UserType = UserType.Admin;
                        ConsoleHelpers.Buffer = "Updated user!";
                        break;
                    case UserCrudCommand.Remove:
                        var idToRemove = InputHelper.DisplayAndGetElementBySelection(DataBase.Users, "Remove user");
                        if (DataBase.Users[idToRemove].UserType == UserType.Admin)
                            throw new AccessDeniedException("You can't remove Admin User!");
                        UserService.RemoveUser(DataBase.Users[idToRemove].Id);
                        ConsoleHelpers.BufferError("Removed user!");
                        break;
                }
            } while (command != UserCrudCommand.Quit);
        }


        public void DisplayProductsMenu()
        {
            InputHelper.DisplayProductsAndGetBasketFromConsole(LoggedInUser.Basket,
                SaleProds
                ,"How many? ");
        }

        public void LoginUser()
        {
            (string username, string password) = UserHelper.GetLoginCreds();
            LoggedInUser = LoginRegisterService.Login(username, password);
            ConsoleHelpers.Buffer = $"Welcome back {LoggedInUser.Name}";
        }

        public void RegisterUser()
        {
            ConsoleHelpers.PrintBuffer();
            var userDto = UserHelper.GetUserDetails();
            LoginRegisterService.Register(userDto.name,userDto.surname,userDto.password,userDto.username);
        }

    }
}
