using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Interface
{
    public interface IPortfolio
    {
		bool CreateNewItem(PortfolioItem b);
		List<PortfolioItem> RetrieveAllItems();
		bool DeleteItemById(int itemId);
		bool UpdateItemById(PortfolioItem b);
		PortfolioItem RetrieveItemById(int id);
	}
}
