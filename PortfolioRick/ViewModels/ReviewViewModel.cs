using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.ViewModels
{
    public class ReviewViewModel
    {
		public int reviewId { get; set; }
		public string reviewName { get; set; }
		public string reviewMessage { get; set; }

		public List<ReviewItemViewModel> listofReviews { get; set; } = new List<ReviewItemViewModel>();
    }
}
