using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Models
{
    public class BlogItem
    {
		private int itemId;
		private string itemTitle;
		private string itemMessage;

		public string Thumbnail { get; set; }
		public int Publised { get; set; }
		public DateTime CreatedDate { get; set; }

		public BlogItem(int Id, string Title, string Message)
		{
			itemId = Id;
			itemTitle = Title;
			itemMessage = Message;
		}

		public int RetrieveId()
		{
			return itemId;
		}

		public string RetrieveTitle()
		{
			return itemTitle;
		}

		public string RetrieveMessage()
		{
			return itemMessage;
		}
    }
}
