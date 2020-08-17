using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.ViewModels
{
    public class BlogViewModel
    {
		public int itemId { get; set; }
		public string itemTitle { get; set; }
		public string itemMessage { get; set; }
		public string Thumbnail { get; set; }
		public int published { get; set; }
		public DateTime createdDate { get; set; }
		public List<BlogItemViewModel> BlogItemsInSystem { get; set; } = new List<BlogItemViewModel>();
    }
}
