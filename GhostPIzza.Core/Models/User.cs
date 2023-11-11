using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.Core.Models
{
    public class User
    {
        private static int _idCounter = 1;

        public int Id { get; init; } = _idCounter++;
        public UserType UserType { get; set; } = UserType.RegularUser;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string UserName { get; init; }

        public User(string name, string surname, string password, string username)
        {
            Name = name;
            Surname = surname;
            Password = password;
            UserName = username;
        }

        public Basket Basket { get; set; } = new();

        public override string ToString()
        {
            return $"{Id} {Name} {Surname} {UserName}";
        }
    }
}

