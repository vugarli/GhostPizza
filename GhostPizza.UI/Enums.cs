using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.UI
{
    public enum LoginRegisterMenuCommand
    {
        Login,
        Register
    }

    public enum UserMenuCommand
    {
        Show_All_Pizzas,
        Order,
        CRUD_Pizza,
        CRUD_User
    }

    public enum PizzaCrudCommand
    {
        Show_All,
        Add,
        Update,
        Remove
    }
    public enum UserCrudCommand
    {
        Show_All,
        Add,
        Update,
        Remove
    }


}
