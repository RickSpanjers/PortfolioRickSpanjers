using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using PortfolioRick.Interface;
using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PortfolioRick.Contexts.MYSQL
{
	public class RoleMYSQLContext : ConnectionHelper, IRoleStore<Role>, IRole
	{
		private readonly string _connectionString;
		public RoleMYSQLContext(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		public RoleMYSQLContext()
		{

		}

		public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{

		}

		public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
		{
			try
			{
				cancellationToken.ThrowIfCancellationRequested();

				using (var connection = new MySqlConnection(_connectionString))
				{
					connection.Open();
					MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM Role", connection);
					using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
					{
						Role role = default(Role);
						if (sqlDataReader.Read())
						{
							role = new Role(-1, null, null);
						}
						return Task.FromResult<Role>(role);
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
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

		public bool CreateNewRole(Role r)
		{
			MySqlConnection cnn = ReturnMYSQLConnection();
			string query = "INSERT INTO Role (Name, Description) VALUES (@Name, @Description)";
			MySqlCommand newCmd = CreateMYSQLCommandText(query, cnn);
			newCmd.Parameters.AddWithValue("@Name", r.RetrieveRoleName());
			newCmd.Parameters.AddWithValue("@Description", r.RetrieveDescription());
			newCmd.ExecuteNonQuery();
			cnn.Close();
			return true;
		}

		public bool DeleteRoleById(int roleId)
		{
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				var query = "DELETE FROM Role WHERE ID = @Id";
				MySqlCommand cmd = CreateMYSQLCommandText(query, cnn);
				cmd.Parameters.AddWithValue("@Id", roleId);
				cmd.ExecuteNonQuery();
				cnn.Close();
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return false;
		}

		public bool InsertRolesForUser(int roleId, int userId)
		{
			try
			{
				SqlConnection cnn = ReturnSQLConnection();
				string query = "INSERT INTO userrole (User_ID, Role_ID) VALUES (@userId, @RoleId)";
				SqlCommand newCmd = CreateSQLCommandText(query, cnn);
				newCmd.Parameters.AddWithValue("@userId", userId);
				newCmd.Parameters.AddWithValue("@RoleId", roleId);
				newCmd.ExecuteNonQuery();
				cnn.Close();
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return false;
		}

		public List<Role> RetrieveAllRoles()
		{
			List<Role> listOfRoles = new List<Role>();
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				string query = "SELECT * FROM Role";
				MySqlCommand cmd = CreateMYSQLCommandText(query, cnn);
				MySqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					int roleId = Convert.ToInt32(dr["ID"]);
					string name = dr["Name"].ToString();
					string description = dr["Description"].ToString();
					Role role = new Role(roleId, name, description);
					listOfRoles.Add(role);
				}

				cnn.Close();
			}
			catch (NullReferenceException e)
			{
				Console.WriteLine(e.Message);
			}
			return listOfRoles;
		}

		public Role RetrieveRoleById(int id)
		{
			Role role = new Role(1, null, null);
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				MySqlCommand newCmd = CreateMYSQLCommandText("SELECT * FROM Role WHERE ID=@ID", cnn);
				newCmd.Parameters.AddWithValue("@ID", id);
				MySqlDataReader dr = newCmd.ExecuteReader();
				while (dr.Read())
				{
					int roleId = Convert.ToInt32(dr["ID"]);
					string name = dr["Name"].ToString();
					string description = dr["Description"].ToString();
					role = new Role(roleId, name, description);
				}
				cnn.Close();
			}
			catch (NullReferenceException e)
			{
				Console.WriteLine(e.Message);
			}
			return role;
		}

		public List<Role> RetrieveRolesFromUser(User u)
		{
			List<Role> listOfRoles = new List<Role>();
			try
			{
				SqlConnection cnn = ReturnSQLConnection();
				string query = "SELECT * FROM Role AS R INNER JOIN Userrole as UR on R.ID = UR.Role_ID WHERE UR.User_ID = @userId";
				SqlCommand newCmd = CreateSQLCommandText(query, cnn);
				newCmd.Parameters.AddWithValue("@userId", u.RetrieveUserId());
				SqlDataReader dr = newCmd.ExecuteReader();
				while (dr.Read())
				{
					int roleId = Convert.ToInt32(dr["ID"]);
					string name = dr["Name"].ToString();
					string description = dr["Description"].ToString();
					Role role = new Role(roleId, name, description);
					listOfRoles.Add(role);
				}
				cnn.Close();
			}
			catch (NullReferenceException e)
			{
				Console.WriteLine(e.Message);
			}
			return listOfRoles;
		}

		public bool UpdateRoleById(Role r)
		{

			MySqlConnection cnn = ReturnMYSQLConnection();
			string query = "UPDATE Role SET Name=@Name, Description=@Desc WHERE ID = @Id";
			MySqlCommand newCmd = CreateMYSQLCommandText(query, cnn);
			newCmd.Parameters.AddWithValue("@Id", r.RetrieveRoleId());
			newCmd.Parameters.AddWithValue("@Name", r.RetrieveRoleName());
			newCmd.Parameters.AddWithValue("@Desc", r.RetrieveDescription());
			newCmd.ExecuteNonQuery();
			cnn.Close();
			return true;
		}
	}
}
