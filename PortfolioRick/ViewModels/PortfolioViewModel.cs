using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.ViewModels
{
    public class PortfolioViewModel
    {
		public int itemId { get; set; }
		public string itemName { get; set; }
		public string itemDesc { get; set; }
		public string FrontpageImg { get; set; }
		public string Thumbnail { get; set; }
		public string categoryName { get; set; }
		public string itemTitle { get; set; }
		public DateTime createdDate { get; set; }
		public string urlTitle { get; set; }
		public string urlLink { get; set; }

		public List<PortfolioItemViewModel> listOfPortfolioItems { get; set; } = new List<PortfolioItemViewModel>();
    }
}
