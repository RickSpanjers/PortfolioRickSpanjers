using PortfolioRick.Interface;
using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Repositories
{
    public class UserRepository
    {
		private readonly IUser userInterface;

		public UserRepository(IUser context)
		{
			userInterface = context;
		}

		public List<User> RetrieveAllUsers()
		{
			return userInterface.RetrieveAllUsers();
		}

		public bool UpdateUserById(User u)
		{
			return userInterface.UpdateUserById(u);
		}

		public bool CreateNewUser(User u)
		{
			return userInterface.CreateNewUser(u);
		}

		public bool DeleteUserById(int userId)
		{
			return userInterface.DeleteUserById(userId);
		}

		public User RetrieveUserById(int id)
		{
			return RetrieveUserById(id);
		}
	}
}
