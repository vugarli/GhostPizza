using GhostPizza.UI.ExceptionRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GhostPizza.UI.Validators
{
    internal static class OrderValidators
    {
        private const string PhonePattern = @"^\+[1-9]\d{1,2}\s[0-9][0-9][0-9]\s?\d{3}\s ?\d{2}\s ?\d{2}$";
        public static void ValidatePhoneNumber(string phoneNumber)
        {
            var match = Regex.IsMatch(phoneNumber, PhonePattern);
            if (!match)
                throw new PhoneNumberInvalidException("Invalid Phonenumber!");
        }
    }
}
