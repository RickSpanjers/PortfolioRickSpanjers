using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.ViewModels
{
    public class RoleOverviewViewModel
    {
		public int roleId { get; set; }
		public string roleName { get; set; }
		public string roleDescription { get; set; }

		public List<RoleViewModel> listofRoles { get; set; } = new List<RoleViewModel>();
    }
}
