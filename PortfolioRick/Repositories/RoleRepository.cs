using PortfolioRick.Interface;
using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Repositories
{
    public class RoleRepository
    {
		private readonly IRole roleInterface;

		public RoleRepository(IRole context)
		{
			roleInterface = context;
		}

		public List<Role> RetrieveAllRoles()
		{
			return roleInterface.RetrieveAllRoles();
		}

		public bool UpdateRoleById(Role r)
		{
			return roleInterface.UpdateRoleById(r);
		}

		public bool CreateNewRole(Role r)
		{
			return roleInterface.CreateNewRole(r);
		}

		public bool DeleteRoleById(int roleId)
		{
			return roleInterface.DeleteRoleById(roleId);
		}

		public bool InsertRolesForUser(int roleId, int userId)
		{
			return roleInterface.InsertRolesForUser(roleId, userId);
		}

		public List<Role> RetrieveRolesFromUser(User u)
		{
			return roleInterface.RetrieveRolesFromUser(u);
		}

		public Role RetrieveRoleById(int id)
		{
			return roleInterface.RetrieveRoleById(id); ;
		}
	}
}
