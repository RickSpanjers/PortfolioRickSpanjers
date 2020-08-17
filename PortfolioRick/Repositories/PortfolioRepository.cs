using PortfolioRick.Interface;
using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Repositories
{
    public class PortfolioRepository
    {
		private readonly IPortfolio portfolioInterface;

		public PortfolioRepository(IPortfolio context)
		{
			portfolioInterface = context;
		}

		public bool CreateNewItem(PortfolioItem b)
		{
			return portfolioInterface.CreateNewItem(b);
		}

		public List<PortfolioItem> RetrieveAllItems()
		{
			return portfolioInterface.RetrieveAllItems();
		}

		public bool DeleteItemById(int itemId)
		{
			return portfolioInterface.DeleteItemById(itemId);
		}

		public bool UpdateItemById(PortfolioItem b)
		{
			return portfolioInterface.UpdateItemById(b);
		}

		public PortfolioItem RetrieveItemById(int id)
		{
			return portfolioInterface.RetrieveItemById(id);
		}
	}
}
