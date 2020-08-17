using Microsoft.AspNetCore.Http;
using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Helpers
{
    public class SessionHelper
    {
		private IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
		private readonly AutoMapperExtension mapextension = new AutoMapperExtension();

		public void UpdateSessionsUser(User selectedUser)
		{
			
		}
	}
}
