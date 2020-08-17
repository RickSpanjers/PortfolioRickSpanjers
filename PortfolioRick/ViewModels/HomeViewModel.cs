using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.ViewModels
{
    public class HomeViewModel
    {
		public List<ReviewItemViewModel> listofReviews { get; set; } = new List<ReviewItemViewModel>();
		public List<PortfolioItemViewModel> listofPortfolioitems { get; set; } = new List<PortfolioItemViewModel>();
    }
}
