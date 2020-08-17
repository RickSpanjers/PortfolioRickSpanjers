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
    public class ReviewController : Controller
    {
		ReviewRepository reviewRepo = new ReviewRepository(new ReviewMYSQLContext());
		AutoMapperExtension mapperHelper = new AutoMapperExtension();


		[Authorize]
		public IActionResult Overview(int itemId)
		{
			ReviewViewModel model = new ReviewViewModel();
			model.listofReviews = new List<ReviewItemViewModel>();
			var mapperReview = mapperHelper.ReviewToReviewItemViewModel();
			
			foreach (Review r in reviewRepo.RetrieveAllReviews())
			{
				ReviewItemViewModel rmodel = mapperReview.Map<ReviewItemViewModel>(r);
				model.listofReviews.Add(rmodel);
			}

			if(itemId != 0)
			{
				Review r = reviewRepo.RetrieveReviewById(itemId);
				model.reviewId = r.RetrieveId();
				model.reviewMessage = r.RetrieveMessage();
				model.reviewName = r.RetrieveName();
			}

			return View("ReviewOverview", model);
		}

		[Authorize]
		public IActionResult Add(ReviewItemViewModel model)
		{
			Review r = new Review(-1, model.reviewName, model.reviewMessage);
			if(reviewRepo.CreateNewReview(r) == true)
			{
				return RedirectToAction("Overview");
			}
			return RedirectToAction("Single");
		}

		[Authorize]
		public IActionResult Update(ReviewItemViewModel model)
		{
			Review r = new Review(model.reviewId, model.reviewName, model.reviewMessage);
			if(reviewRepo.UpdateReviewById(r) == true)
			{
				return RedirectToAction("Overview");
			}
			return RedirectToAction("Single");
		}

		[Authorize]
		public IActionResult Delete(int reviewToDelete)
		{
			if(reviewRepo.DeleteReviewById(reviewToDelete) == true)
			{
				return RedirectToAction("Overview");
			}
			return RedirectToAction("Overview");
		}

		[Authorize]
		public IActionResult Single(int reviewToUpdate)
		{
			if(reviewToUpdate != 0)
			{
				Review r = reviewRepo.RetrieveReviewById(reviewToUpdate);
				var mapperReview = mapperHelper.ReviewToReviewItemViewModel();
				ReviewItemViewModel rmodel = mapperReview.Map<ReviewItemViewModel>(r);
				return View("Single", rmodel);
			}
			else
			{
				return View("Single");
			}
		}
    }
}