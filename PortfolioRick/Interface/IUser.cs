using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Interface
{
    public interface IUser
    {
		List<User> RetrieveAllUsers();
		bool UpdateUserById(User u);
		bool CreateNewUser(User u);
		bool DeleteUserById(int userId);
		User RetrieveUserById(int userId);
	}
}
