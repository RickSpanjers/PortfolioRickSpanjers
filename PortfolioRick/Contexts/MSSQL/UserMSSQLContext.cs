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
	public class UserMSSQLContext : ConnectionHelper, IUserStore<User>, IUserPasswordStore<User>, IUserEmailStore<User>, IUserRoleStore<User>
	{
		public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public bool CreateNewUser(User u)
		{
			throw new NotImplementedException();
		}

		public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public bool DeleteUserById(int userId)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public List<User> RetrieveAllUsers()
		{
			throw new NotImplementedException();
		}

		public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public bool UpdateUserById(User u)
		{
			throw new NotImplementedException();
		}
	}
}
