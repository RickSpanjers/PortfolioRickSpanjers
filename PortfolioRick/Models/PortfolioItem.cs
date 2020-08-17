using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Models
{
    public class PortfolioItem
    {
		private int itemId;
		private string itemTitle;
		private string itemDesc;

		public string FrontpageImg { get; set; }
		public string Thumbnail { get; set; }
		public string categoryName { get; set; }
		public DateTime createdDate { get; set; }
		public string urlTitle { get; set; }
		public string urlLink { get; set; }

		public PortfolioItem(int Id, string ItemTitle, string ItemDesc)
		{
			itemId = Id;
			itemTitle = ItemTitle;
			itemDesc = ItemDesc;
		}

		public int RetrieveId()
		{
			return itemId;
		}

		public string RetrieveTitle()
		{
			return itemTitle;
		}

		public string RetrieveDescription()
		{
			return itemDesc;
		}
    }
}
