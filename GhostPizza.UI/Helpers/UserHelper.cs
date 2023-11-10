using GhostPizza.Core.Models;
using GhostPizza.Core.Validators;
using GhostPizza.InfraStructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.UI.Helpers
{

    public record UserDto(string name, string surname, string username, string password);

    public class UserBuilder
    {
        private string _name;
        public string Name 
        { 
            get => _name;
            set 
            {
                Validators.ValidateName(value);
                _name = value;
            } 
        }
        private string _surname;
        public string Surname 
        { 
            get => _surname;
            set 
            {
                Validators.ValidateName(value);
                _surname = value;
            } 
        }
        private string _username;
        public string Username
        { 
            get => _username;
            set 
            {
                UserService.UsernameCheck(value);
                _username = value;
            } 
        }
        private string _password;
        public string Password
        { 
            get => _password;
            set 
            {
                Validators.ValidatePassword(value);
                _password = value;
            } 
        }

        public UserDto Build()
        {
            return new UserDto(Name,Surname, Username,Password);
        }

    }

    internal static class UserHelper
    {
        public static (string username, string password )GetLoginCreds()
        {
            var username = InputHelper.PromptAndTryGetNonEmptyString("Username: ");
            var password = InputHelper.PromptAndTryGetNonEmptyString("Password: ");
            return (username, password);
        }

        public static UserDto GetUserDetails()
        {
            UserBuilder ub = new();
            ub.Name = InputHelper.PromptAndTryGetNonEmptyString("Name: ");
            ub.Surname = InputHelper.PromptAndTryGetNonEmptyString("Surname: ");
            ub.Username = InputHelper.PromptAndTryGetNonEmptyString("Username: ");
            ub.Password = InputHelper.PromptAndTryGetNonEmptyString("Password: ");
            return ub.Build();
        }
    }
}
