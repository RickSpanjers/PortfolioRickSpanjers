using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.ViewModels
{
    public class UserOverviewViewModel
    {
		public int userId { get; set; }
		public string emailAddress { get; set; }
		public string password { get; set; }
		public RoleViewModel role { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Address { get; set; }
		public string Zipcode { get; set; }
		public string Place { get; set; }

		public List<UserViewModel> listofUsers { get; set; } = new List<UserViewModel>();
    }
}
