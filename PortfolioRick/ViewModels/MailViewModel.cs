using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.ViewModels
{
    public class MailViewModel
    {
		public string Email { get; set; } 
		public string Subject { get; set; }
		public string Message { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Phone { get; set; }
		public string Zipcode { get; set; }
		public string Place { get; set; }
		public string Address { get; set; }
    }
}
