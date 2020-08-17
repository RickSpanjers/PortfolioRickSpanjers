using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Models
{
    public class User
    {
		private int userId;
		private string emailAddress;
		private string password;
		private Role role;

		public string Username { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Address { get; set; }
		public string Zipcode { get; set; }
		public string Place { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		public User(int Id, string Email, string Password)
		{
			userId = Id;
			emailAddress = Email;
			password = Password;
		}

		public User(int id)
		{
			userId = id;
		}

		public int RetrieveUserId()
		{
			return userId;
		}	
		
		public string RetrieveEmail()
		{
			return emailAddress;
		}

		public string RetrievePassword()
		{
			return password;
		}

		public Role RetrieveRole()
		{
			return role;
		}

		public void SetRole(Role r)
		{
			role = r;
		}
    }
}
