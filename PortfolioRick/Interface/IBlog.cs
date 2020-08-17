using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Interface
{
	public interface IBlog
    {
		bool CreateNewBlogItem(BlogItem b);
		List<BlogItem> RetrieveAllBlogItems();
		bool DeleteBlogItemById(int itemId);
		bool UpdateBlogItemById(BlogItem b);
		BlogItem RetrieveBlogItemById(int id);
	}
}
