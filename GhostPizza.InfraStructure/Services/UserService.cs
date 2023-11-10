using GhostPizza.Core.Models;
using GhostPizza.InfraStructure.Exceptions;

namespace GhostPizza.InfraStructure.Services
{
	internal static class UserService
	{
		public static void AddUser(User user)
		{
			DataBase.Users.Add(user);
		}

		public static void RemoveUser(int id)
		{
			DataBase.Users.Remove(GetUserById(id));
		}

		public static void UpdateUserRole(int id, UserType newUserType)
		{
			GetUserById(id).UserType = newUserType;
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
			return DataBase.Users;
		}
	}
}
