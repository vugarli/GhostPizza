using GhostPizza.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.Core.Validators
{
    static class Validators
    {
        public static void ValidateName(string name)
        {
            if (name.Length < 3 || name.Length > 16)
            {
                throw new InvalidUserNameException("Username must be 3-16 characters long.");
            }
        }

        public static void ValidatePassword(string password)
        {
            if (password.Length < 6 || password.Length > 16)
            {
                throw new InvalidPasswordException("The password must be 6-16 characters long.");
            }

            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasDigit = false;

            foreach (char character in password)
            {
                if (char.IsUpper(character))
                {
                    hasUppercase = true;
                }
                else if (char.IsLower(character))
                {
                    hasLowercase = true;
                }
                else if (char.IsDigit(character))
                {
                    hasDigit = true;
                }
            }

            if (!hasUppercase || !hasLowercase || !hasDigit)
            {
                throw new InvalidPasswordException("Password must contain at least one uppercase letter, one lowercase letter, and one digit.");
            }
        }
    }
}
