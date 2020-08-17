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
	public class UserMYSQLContext : ConnectionHelper, IUserStore<User>, IUserPasswordStore<User>, IUserEmailStore<User>, IUserRoleStore<User>, IUser
	{

		private readonly string _connectionString;
		public UserMYSQLContext(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		public UserMYSQLContext()
		{
		}

		public bool CreateNewUser(User u)
		{
			string sqlUserInsert = "INSERT INTO User (Username, Password, Firstname, Lastname, Email, Address, Zipcode, Place) VALUES (@Username, @Password, @Firstname, @Lastname, @Email, @Address, @Zipcode, @Place)";
			using (MySqlConnection cnn = ReturnMYSQLConnection())
			{
				int affectedRows = cnn.Execute(sqlUserInsert, new { Username = u.Username, Password = u.Password, Firstname = u.Firstname, Lastname = u.Lastname, Email = u.Email, Address = u.Address, Zipcode = u.Zipcode, Place = u.Place });
				return true;
			}
		}

		public bool DeleteUserById(int userId)
		{
			string sqlUserDelete = "DELETE FROM User WHERE ID = @Id";
			using (MySqlConnection cnn = ReturnMYSQLConnection())
			{
				try
				{
					int affectedRows = cnn.Execute(sqlUserDelete, new { ID = userId });
					return true;
				}
				catch (NullReferenceException e)
				{
					Console.WriteLine(e.Message);
					return false;
				}
			}
		}

		public List<User> RetrieveAllUsers()
		{
			var listOfItems = new List<User>();
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				var query = "SELECT * FROM User";
				MySqlCommand cmd = CreateMYSQLCommandText(query, cnn);

				var dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					int itemId = Convert.ToInt32(dr["ID"]);
					string Username = dr["Username"].ToString();
					string Password = dr["Password"].ToString();
					string Firstname = dr["Firstname"].ToString();
					string Lastname = dr["Lastname"].ToString();
					string Email = dr["Email"].ToString();
					string Address = dr["Address"].ToString();
					string Zipcode = dr["Zipcode"].ToString();
					string Place = dr["Place"].ToString();

					User u = new User(itemId, Email, Password);
					u.Username = Username;
					u.Password = Password;
					u.Firstname = Firstname;
					u.Lastname = Lastname;
					u.Email = Email;
					u.Address = Address;
					u.Zipcode = Zipcode;
					u.Place = Place;

					listOfItems.Add(u);
				}
				cnn.Close();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return listOfItems;
		}

		public bool UpdateUserById(User u)
		{
			throw new NotImplementedException();
		}


		public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
		{
			try
			{
				cancellationToken.ThrowIfCancellationRequested();
				using (var connection = new MySqlConnection(_connectionString))
				{
					connection.Open();
					MySqlCommand sqlCommand = new MySqlCommand("INSERT INTO User (Username, Password, Email) VALUES (@Username, @Password, @Email); SELECT LAST_INSERT_ID();", connection);
					sqlCommand.Parameters.AddWithValue("@Username", user.Username);
					sqlCommand.Parameters.AddWithValue("@Password", user.Password);
					sqlCommand.Parameters.AddWithValue("@Email", user.Email);

					var Id = Convert.ToInt32(sqlCommand.ExecuteScalar());

					User u = new User(Id);
					u.Username = user.Username;
					u.Email = user.Email;
					u.Password = user.Password;
					user = u;

					return Task.FromResult<IdentityResult>(IdentityResult.Success);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{

		}

		/// <summary>
		/// Finding a user by Email in the database
		/// </summary>
		/// <param name="normalizedEmail"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			using (var connection = new MySqlConnection(_connectionString))
			{
				connection.Open();
				MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM User WHERE email=@email", connection);
				sqlCommand.Parameters.AddWithValue("@email", normalizedEmail);
				using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
				{
					User user = default(User);
					if (sqlDataReader.Read())
					{
						user = new User(Convert.ToInt32(sqlDataReader["id"].ToString()));
						user.Firstname = sqlDataReader["Firstname"].ToString();
						user.Lastname = sqlDataReader["Lastname"].ToString();
						user.Address = sqlDataReader["Address"].ToString();
						user.Email = sqlDataReader["Email"].ToString();
						user.Place = sqlDataReader["Place"].ToString();
						user.Username = sqlDataReader["Username"].ToString();
						user.Zipcode = sqlDataReader["Zipcode"].ToString();
						user.Password = sqlDataReader["password"].ToString();

					}
					return Task.FromResult(user);
				}
			}
		}

		public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
		{
			try
			{
				cancellationToken.ThrowIfCancellationRequested();
				using (var connection = new MySqlConnection(_connectionString))
				{
					connection.Open();
					MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM User WHERE id=@id", connection);
					sqlCommand.Parameters.AddWithValue("@id", userId);
					using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
					{
						User user = default(User);
						if (sqlDataReader.Read())
						{
							user = new User(Convert.ToInt32(sqlDataReader["id"].ToString()));
							user.Firstname = sqlDataReader["Firstname"].ToString();
							user.Lastname = sqlDataReader["Lastname"].ToString();
							user.Address = sqlDataReader["Address"].ToString();
							user.Email = sqlDataReader["Email"].ToString();
							user.Place = sqlDataReader["Place"].ToString();
							user.Username = sqlDataReader["Username"].ToString();
							user.Zipcode = sqlDataReader["Zipcode"].ToString();
							user.Password = sqlDataReader["password"].ToString();
						}
						return Task.FromResult(user);
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
		{
			try
			{
				cancellationToken.ThrowIfCancellationRequested();
				using (var connection = new MySqlConnection(_connectionString))
				{
					connection.Open();
					MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM User WHERE username=@username", connection);
					sqlCommand.Parameters.AddWithValue("@username", normalizedUserName);
					using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
					{
						User user = default(User);
						if (sqlDataReader.Read())
						{
							user = new User(Convert.ToInt32(sqlDataReader["id"].ToString()));
							user.Firstname = sqlDataReader["Firstname"].ToString();
							user.Lastname = sqlDataReader["Lastname"].ToString();
							user.Address = sqlDataReader["Address"].ToString();
							user.Email = sqlDataReader["Email"].ToString();
							user.Place = sqlDataReader["Place"].ToString();
							user.Username = sqlDataReader["Username"].ToString();
							user.Zipcode = sqlDataReader["Zipcode"].ToString();
							user.Password = sqlDataReader["password"].ToString();
						}
						return Task.FromResult(user);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
		}

		public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.Username);
		}

		public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.RetrieveUserId().ToString());
		}

		public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.Username);
		}

		public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
		{
			user.Username = normalizedName;
			return Task.FromResult(0);
		}

		public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
		{
			user.Username = userName;
			return Task.FromResult(0);
		}

		public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
		{
			user.Password = passwordHash;
			return Task.FromResult(0);
		}

		public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.Password);
		}

		public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.Password != null);
		}

		public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
		{
			user.Email = email;
			return Task.FromResult(0);
		}

		public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.Email);
		}

		public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.Email);
		}

		public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
		{
			user.Email = normalizedEmail;
			return Task.FromResult(0);
		}

		public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
		{
			try
			{
				cancellationToken.ThrowIfCancellationRequested();

				using (var connection = new MySqlConnection(_connectionString))
				{
					connection.Open();
					MySqlCommand sqlCommand = new MySqlCommand("SELECT Name FROM Role r INNER JOIN UserRole ur ON ur.RoleID = r.id WHERE ur.UserID = @userId", connection);
					sqlCommand.Parameters.AddWithValue("@userId", user.RetrieveUserId());
					using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
					{
						IList<string> roles = new List<string>();
						while (sqlDataReader.Read())
						{
							roles.Add(sqlDataReader["Name"].ToString());
						}
						return Task.FromResult(roles);
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
		{
			try
			{
				cancellationToken.ThrowIfCancellationRequested();

				using (var connection = new MySqlConnection(_connectionString))
				{
					connection.Open();

					MySqlCommand sqlCommand = new MySqlCommand("SELECT [id] FROM Role WHERE [name] = @normalizedName", connection);
					sqlCommand.Parameters.AddWithValue("@normalizedName", roleName.ToUpper());
					int? roleId = sqlCommand.ExecuteScalar() as int?;

					MySqlCommand sqlCommandUserRole = new MySqlCommand("SELECT COUNT(*) FROM UserRole WHERE [userId] = @userId AND [roleId] =@roleId", connection);
					sqlCommandUserRole.Parameters.AddWithValue("@userId", user.RetrieveUserId());
					sqlCommandUserRole.Parameters.AddWithValue("@roleId", roleId);

					int? roleCount = sqlCommandUserRole.ExecuteScalar() as int?;
					return Task.FromResult(roleCount > 0);

				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public User RetrieveUserById(int userId)
		{
			var u = new User(-1, null, null);
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				string query = "SELECT * FROM User WHERE ID=@ID";
				MySqlCommand cmd = CreateMYSQLCommandText(query, cnn);
				cmd.Parameters.AddWithValue("@ID", userId);
				var dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					int itemId = Convert.ToInt32(dr["ID"]);
					string Username = dr["Username"].ToString();
					string Password = dr["Password"].ToString();
					string Firstname = dr["Firstname"].ToString();
					string Lastname = dr["Lastname"].ToString();
					string Email = dr["Email"].ToString();
					string Address = dr["Address"].ToString();
					string Zipcode = dr["Zipcode"].ToString();
					string Place = dr["Place"].ToString();

					u = new User(itemId, Email, Password);
					u.Username = Username;
					u.Password = Password;
					u.Firstname = Firstname;
					u.Lastname = Lastname;
					u.Email = Email;
					u.Address = Address;
					u.Zipcode = Zipcode;
					u.Place = Place;
				}
				cnn.Close();
			}
			catch (NullReferenceException e)
			{
				Console.WriteLine(e.Message);
			}
			return u;
		}
	}
}
