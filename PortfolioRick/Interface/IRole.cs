using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Interface
{
    public interface IRole
    {
		List<Role> RetrieveAllRoles();
		bool UpdateRoleById(Role r);
		bool CreateNewRole(Role r);
		bool DeleteRoleById(int roleId);
		bool InsertRolesForUser(int roleId, int userId);
		List<Role> RetrieveRolesFromUser(User u);
		Role RetrieveRoleById(int id);
	}
}
