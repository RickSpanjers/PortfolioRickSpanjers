using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Models
{
    public class Role
    {
		private int roleId;
		private string roleName;
		private string roleDescription;

		public Role(int Id, string Name, string Desc)
		{
			roleId = Id;
			roleName = Name;
			roleDescription = Desc;
		}

		public int RetrieveRoleId()
		{
			return roleId;
		}

		public string RetrieveRoleName()
		{
			return roleName;
		}

		public string RetrieveDescription()
		{
			return roleDescription;
		}
    }
}
