using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Models
{
    public class Review
    {
		private int reviewId;
		private string reviewName;
		private string reviewMessage;

		public Review(int Id, string Name, string Message)
		{
			reviewId = Id;
			reviewName = Name;
			reviewMessage = Message;
		}

		public int RetrieveId()
		{
			return reviewId;
		}

		public string RetrieveName()
		{
			return reviewName;
		}

		public string RetrieveMessage()
		{
			return reviewMessage;
		}
    }
}
