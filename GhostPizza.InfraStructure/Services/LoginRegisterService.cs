using GhostPizza.Core.Models;
using GhostPizza.InfraStructure.Exceptions;

namespace GhostPizza.InfraStructure.Services
{
	internal static class LoginRegisterService
	{
		public static void Register(string name, string surname, string password, string userName)
		{
			UserService.UsernameCheck(userName);

			var newUser = new User(name, surname, password, userName)
			{
				Name = name,
				Surname = surname,
				Password = password,
				UserName = userName
			};

			DataBase.Users.Add(newUser);
		}

		public static User Login(string username, string password)
		{
			var user = DataBase.Users.Find(user => user.UserName == username && user.Password == password);
			if (user != null)
			{
				return user;
			}
			else
			{
				throw new CredentialsAreInvalidException("User doesn't exist.");
			}
		}
	}
}
