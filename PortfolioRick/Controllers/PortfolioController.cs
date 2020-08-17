using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioRick.Contexts.MYSQL;
using PortfolioRick.Helpers;
using PortfolioRick.Models;
using PortfolioRick.Repositories;
using PortfolioRick.ViewModels;

namespace PortfolioRick.Controllers
{
    public class PortfolioController : Controller
    {
		PortfolioRepository pRepo = new PortfolioRepository(new PortfolioMYSQLContext());
		AutoMapperExtension mapperHelper = new AutoMapperExtension();

		public IActionResult Portfolio()
		{
			PortfolioViewModel model = new PortfolioViewModel();
			model.listOfPortfolioItems = new List<PortfolioItemViewModel>();
			var mapperPortfolio = mapperHelper.PortfolioItemToPortfolioItemViewModel();
			foreach (PortfolioItem p in pRepo.RetrieveAllItems())
			{
				PortfolioItemViewModel pmodel = mapperPortfolio.Map<PortfolioItemViewModel>(p);
				model.listOfPortfolioItems.Add(pmodel);
			}
			return View("OurWork", model);
		}

		[Authorize]
		public IActionResult Overview()
		{
			PortfolioViewModel model = new PortfolioViewModel();
			model.listOfPortfolioItems = new List<PortfolioItemViewModel>();
			var mapperPortfolio = mapperHelper.PortfolioItemToPortfolioItemViewModel();
			foreach (PortfolioItem p in pRepo.RetrieveAllItems())
			{
				PortfolioItemViewModel pmodel = mapperPortfolio.Map<PortfolioItemViewModel>(p);
				model.listOfPortfolioItems.Add(pmodel);
			}
			return View("Overview", model);
		}

		[Authorize]
		public IActionResult Single(int itemToEdit)
		{
			PortfolioItem p = pRepo.RetrieveItemById(itemToEdit);
			var mapperPortfolio = mapperHelper.PortfolioItemToPortfolioItemViewModel();
			PortfolioItemViewModel pmodel = mapperPortfolio.Map<PortfolioItemViewModel>(p);
			return View("SingleItem", pmodel);
		}

		[Authorize]
		public IActionResult Add(PortfolioItemViewModel model, string thumbnail, string frontpageImg)
		{
			PortfolioItem p = new PortfolioItem(-1, model.itemTitle, model.itemDesc);
			p.categoryName = model.categoryName;
			p.FrontpageImg = frontpageImg;
			p.urlLink = model.urlLink;
			p.urlTitle = model.urlTitle;
			p.Thumbnail = thumbnail;

			if(pRepo.CreateNewItem(p) == true)
			{
				return RedirectToAction("Overview");
			}

			return RedirectToAction("Overview");
		}

		[Authorize]
		public IActionResult Delete(int itemToDelete)
		{
			if(pRepo.DeleteItemById(itemToDelete) == true)
			{
				return RedirectToAction("Overview");
			}
			return RedirectToAction("Overview");
		}

		[Authorize]
		public IActionResult Update(PortfolioItemViewModel model, string thumbnail, string frontpageImg)
		{
			PortfolioItem p = new PortfolioItem(model.itemId, model.itemTitle, model.itemDesc);
			p.categoryName = model.categoryName;
			p.FrontpageImg = frontpageImg;
			p.urlLink = model.urlLink;
			p.urlTitle = model.urlTitle;
			p.Thumbnail = thumbnail;

			if (pRepo.UpdateItemById(p) == true)
			{
				return RedirectToAction("Overview");
			}
			return RedirectToAction("Overview");
		}
    }
}