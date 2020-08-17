using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class HomeController : Controller
    {
		ReviewRepository reviewRepo = new ReviewRepository(new ReviewMYSQLContext());
		PortfolioRepository portfolioRepo = new PortfolioRepository(new PortfolioMYSQLContext());
		AutoMapperExtension mapperHelper = new AutoMapperExtension();

		public IActionResult Index()
        {
			HomeViewModel model = new HomeViewModel();
			model.listofReviews = new List<ReviewItemViewModel>();
			var mapperReview = mapperHelper.ReviewToReviewItemViewModel();
			foreach (Review r in reviewRepo.RetrieveAllReviews())
			{
				ReviewItemViewModel rmodel = mapperReview.Map<ReviewItemViewModel>(r);
				model.listofReviews.Add(rmodel);
			}

			model.listofPortfolioitems = new List<PortfolioItemViewModel>();
			var mapperPortfolio = mapperHelper.PortfolioItemToPortfolioItemViewModel();
			foreach (PortfolioItem p in portfolioRepo.RetrieveAllItems())
			{
				PortfolioItemViewModel pmodel = mapperPortfolio.Map<PortfolioItemViewModel>(p);
				model.listofPortfolioitems.Add(pmodel);
			}

			return View("Index", model);
        }

        public IActionResult About()
        {
            return View();
        }

		public IActionResult WhatWeDo()
		{
			return View("Whatwedo");
		}

        public IActionResult Contact()
        {  
            return View();
        }

		[Authorize]
		public IActionResult Dashboard()
		{
			return View();
		}

		public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
