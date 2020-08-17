using PortfolioRick.Interface;
using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Repositories
{
    public class BlogRepository
    {
		private readonly IBlog blogInterface;

		public BlogRepository(IBlog context)
		{
			blogInterface = context;
		}

		public bool CreateNewBlogItem(BlogItem b)
		{
			return blogInterface.CreateNewBlogItem(b);
		}

		public List<BlogItem> RetrieveAllBlogItems()
		{
			return blogInterface.RetrieveAllBlogItems();
		}

		public bool DeleteBlogItemById(int itemId)
		{
			return blogInterface.DeleteBlogItemById(itemId);
		}

		public bool UpdateBlogItemById(BlogItem b)
		{
			return blogInterface.UpdateBlogItemById(b);
		}

		public BlogItem RetrieveBlogItemById(int id)
		{
			return blogInterface.RetrieveBlogItemById(id);
		}
	}
}
