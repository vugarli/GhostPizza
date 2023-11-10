using GhostPizza.Core.Models;
using GhostPizza.InfraStructure.Exceptions;

namespace GhostPizza.InfraStructure.Services
{
	internal static class UserService
	{
		public static void AddUser(User user)
		{
			DataBase.Users.Add(user);
			Console.WriteLine("User added.");
		}

		public static void RemoveUser(int id)
		{
			var userToRemove = DataBase.Users.Find(user => user.Id == id);
			if (userToRemove != null)
			{
				DataBase.Users.Remove(userToRemove);
				Console.WriteLine("User removed.");
			}
			else
			{
				throw new UserNotFoundException("User not found.");
			}
		}

		public static void UpdateUserRole(int id, UserType newUserType)
		{
			var existingUser = DataBase.Users.Find(user => user.Id == id);

			if (existingUser != null)
			{
				existingUser.UserType = newUserType;

				Console.WriteLine("User role updated.");
			}
			else
			{
				throw new UserNotFoundException("User not found.");
			}
		}

		public static User GetUserById(int id)
		{
			var user = DataBase.Users.Find(user => user.Id == id);
			if (user != null)
			{
				return user;
			}
			else
			{
				throw new UserNotFoundException("User not found.");
			}
		}

		public static List<User> GetAllUsers()
		{
			return DataBase.Users != null ? DataBase.Users.ToList() : new List<User>();
		}
	}
}
