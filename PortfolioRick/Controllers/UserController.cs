using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioRick.Contexts.MYSQL;
using PortfolioRick.Helpers;
using PortfolioRick.Repositories;
using PortfolioRick.Models;
using PortfolioRick.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace PortfolioRick.Controllers
{
    public class UserController : Controller
    {

		UserRepository userRepo = new UserRepository(new UserMYSQLContext());
		AutoMapperExtension mapperHelper = new AutoMapperExtension();

		[Authorize]
		public IActionResult Overview()
		{
			UserOverviewViewModel model = new UserOverviewViewModel();
			model.listofUsers = new List<UserViewModel>();
			var mapperU = mapperHelper.UserToUserViewModel();
			foreach (User u in userRepo.RetrieveAllUsers())
			{
				UserViewModel umodel = mapperU.Map<UserViewModel>(u);
				model.listofUsers.Add(umodel);
			}
			return View("UserOverview", model);
		}

		[Authorize]
		public IActionResult Single(int userToUpdate)
		{
			if (userToUpdate != 0)
			{
				User u = userRepo.RetrieveUserById(userToUpdate);
				var mapperU = mapperHelper.UserToUserViewModel();
				UserViewModel umodel = mapperU.Map<UserViewModel>(u);
				return View("SingleUser", umodel);
			}
			else
			{
				UserViewModel model = new UserViewModel();
				return View("SingleUser", model);
			}
		}

		[Authorize]
		public IActionResult Add(UserViewModel model)
		{
			User u = new User(-1);
			u.Address = model.Address;
			u.Email = model.emailAddress;
			u.Firstname = model.Firstname;
			u.Lastname = model.Lastname;
			u.Password = model.password;
			u.Place = model.Place;
			u.Username = model.username;
			u.Zipcode = model.Zipcode;

			userRepo.CreateNewUser(u);
			return RedirectToAction("Overview");
		}

		[Authorize]
		public IActionResult Delete(int userToDelete)
		{
			userRepo.DeleteUserById(userToDelete);
			return RedirectToAction("Overview");
		}

		[Authorize]
		public IActionResult Update(UserViewModel model)
		{
			User u = new User(model.userId);
			u.Address = model.Address;
			u.Email = model.emailAddress;
			u.Firstname = model.Firstname;
			u.Lastname = model.Lastname;
			u.Password = model.password;
			u.Place = model.Place;
			u.Username = model.username;
			u.Zipcode = model.Zipcode;

			userRepo.UpdateUserById(u);
			return RedirectToAction("Overview");
		}
    }
}