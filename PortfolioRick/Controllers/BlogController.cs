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
    public class BlogController : Controller
    {

		BlogRepository blogRepo = new BlogRepository(new BlogMYSQLContext());
		AutoMapperExtension mapper = new AutoMapperExtension();

		[Authorize]
		public IActionResult Add(BlogViewModel model, string blogImage)
		{
			BlogItem b = new BlogItem(-1, model.itemTitle, model.itemMessage);
			b.CreatedDate = DateTime.Now;
			b.Publised = model.published;
			b.Thumbnail = blogImage;

			if(blogRepo.CreateNewBlogItem(b) == true)
			{
				return RedirectToAction("Overview");
			}

			return RedirectToAction("Overview");
		}

		[Authorize]
		public IActionResult Delete(int itemToDelete)
		{
			if(blogRepo.DeleteBlogItemById(itemToDelete) == true)
			{
				return RedirectToAction("Overview");
			}
			else
			{
				return RedirectToAction("Overview");
			}
		}

		[Authorize]
		public IActionResult Update(BlogViewModel model, int blogId, string blogImage)
		{
			BlogItem b = new BlogItem(blogId, model.itemTitle, model.itemMessage);
			b.CreatedDate = DateTime.Now.Date;
			b.Publised = model.published;
			b.Thumbnail = blogImage;

			if(blogRepo.UpdateBlogItemById(b) == true)
			{
				return RedirectToAction("Overview");
			}

			return RedirectToAction("Overview");

		}

		public IActionResult Blog()
		{
			BlogViewModel model = new BlogViewModel();
			model.BlogItemsInSystem = new List<BlogItemViewModel>();
			var mapperBlog = mapper.BlogToBlogItemViewModel();
			foreach (BlogItem b in blogRepo.RetrieveAllBlogItems())
			{
				BlogItemViewModel bmodel = mapperBlog.Map<BlogItemViewModel>(b);
				model.BlogItemsInSystem.Add(bmodel);
			}

			return View("Blogpage", model);
		}

		public IActionResult Post(int blogToSee)
		{
			BlogItem b = blogRepo.RetrieveBlogItemById(blogToSee);
			var mapperBlog = mapper.BlogToBlogItemViewModel();
			BlogItemViewModel bmodel = mapperBlog.Map<BlogItemViewModel>(b);
			return View("Singleblog", bmodel);
		}

		[Authorize]
		public IActionResult Overview()
		{
			BlogViewModel model = new BlogViewModel();
			model.BlogItemsInSystem = new List<BlogItemViewModel>();
			var mapperBlog = mapper.BlogToBlogItemViewModel();
			foreach (BlogItem b in blogRepo.RetrieveAllBlogItems())
			{
				BlogItemViewModel bmodel = mapperBlog.Map<BlogItemViewModel>(b);
				model.BlogItemsInSystem.Add(bmodel);
			}

			return View("BlogOverview", model);
		}

		[Authorize]
		public IActionResult SingleBlogItem(int blogId)
		{
			if(blogId != 0)
			{
				BlogItem b = blogRepo.RetrieveBlogItemById(blogId);
				var mapperBlog = mapper.BlogToBlogItemViewModel();
				BlogItemViewModel bmodel = mapperBlog.Map<BlogItemViewModel>(b);
				return View("SingleBlogItem", bmodel);
			}
			else
			{
				BlogItemViewModel model = new BlogItemViewModel();
				return View("SingleBlogItem", model);
			}
		}
    }
}