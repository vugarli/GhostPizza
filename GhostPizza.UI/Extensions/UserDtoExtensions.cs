using GhostPizza.Core.Models;
using GhostPizza.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.UI.Extensions
{
    internal static class UserDtoExtensions
    {
        public static User ToUser(this UserDto ud)
        {
            return new User(ud.name,ud.surname,ud.password,ud.username);
        }
    }
}
