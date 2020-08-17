using Microsoft.AspNetCore.Identity;
using PortfolioRick.Interface;
using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PortfolioRick.Contexts.MSSQL
{
	public class RoleMSSQLContext : IRoleStore<Role>, IRole
	{
		public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public bool CreateNewRole(Role r)
		{
			throw new NotImplementedException();
		}

		public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public bool DeleteRoleById(int roleId)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public bool InsertRolesForUser(int roleId, int userId)
		{
			throw new NotImplementedException();
		}

		public List<Role> RetrieveAllRoles()
		{
			throw new NotImplementedException();
		}

		public Role RetrieveRoleById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Role> RetrieveRolesFromUser(User u)
		{
			throw new NotImplementedException();
		}

		public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public bool UpdateRoleById(Role r)
		{
			throw new NotImplementedException();
		}
	}
}
