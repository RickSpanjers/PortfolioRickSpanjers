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
    public class RoleController : Controller
    {
		private readonly RoleRepository roleRep = new RoleRepository(new RoleMYSQLContext());
		private readonly UserRepository userRep = new UserRepository(new UserMYSQLContext());
		private readonly AutoMapperExtension mapextension = new AutoMapperExtension();

		[Authorize]
		/// <summary>
		///     Return roleoverview
		/// </summary>
		/// <returns>Return roleoverview</returns>
		public IActionResult Overview()
		{
			var model = new RoleOverviewViewModel();
			model.listofRoles = new List<RoleViewModel>();
			foreach (Role r in roleRep.RetrieveAllRoles())
			{
				var mapper = mapextension.RoleToRoleViewModel();
				RoleViewModel rmodel = mapper.Map<RoleViewModel>(r);
				model.listofRoles.Add(rmodel);
			}
			return View("RoleOverview", model);
		}

		[Authorize]
		/// <summary>
		///     Return roleoverview with info
		/// </summary>
		/// <param name="selectedRole">Id of the role to edit</param>
		/// <returns>Return roleoverview</returns>
		public IActionResult OverviewEdit(int itemId)
		{
			var allRoles = roleRep.RetrieveAllRoles();
			var selected = roleRep.RetrieveRoleById(itemId);
			if (selected.RetrieveRoleId() != 0)
			{
				var mapperOne = mapextension.RoleToRoleOverviewViewModel();
				RoleOverviewViewModel model = mapperOne.Map<RoleOverviewViewModel>(selected);

				model.listofRoles = new List<RoleViewModel>();
				foreach (Role r in roleRep.RetrieveAllRoles())
				{
					var mapperTwo = mapextension.RoleToRoleViewModel();
					RoleViewModel rmodel = mapperTwo.Map<RoleViewModel>(r);
					model.listofRoles.Add(rmodel);
				}

				return View("Roleoverview", model);
			}
			return View("Roleoverview");
		}


		[Authorize]
		[HttpPost]
		public IActionResult Add(RoleViewModel Model)
		{
			if (Model.roleDescription == null) Model.roleDescription = "No description";
			var role = new Role(-1, Model.roleName, Model.roleDescription);

			if (roleRep.CreateNewRole(role))
			{
				return RedirectToAction("Overview", "Role");
			}
			return RedirectToAction("Overview", "Role");
		}


		/// <summary>
		///     Delete role from system
		/// </summary>
		/// <param name="roleToDelete">Id from Role</param>
		/// <returns>Actionresult roleoverview</returns>
		[HttpPost]
		[Authorize]
		public IActionResult Delete(int roleToDelete)
		{
			var selectedRole = roleRep.RetrieveRoleById(roleToDelete);
			if (selectedRole.RetrieveRoleId() != 0)
			{
				if (roleRep.DeleteRoleById(selectedRole.RetrieveRoleId()))
				{
					return RedirectToAction("Overview", "Role");
				}
			}
			return RedirectToAction("Overview", "Role");
		}


		/// <summary>
		///     Edit role in system
		/// </summary>
		/// <param name="model">RoleViewModel</param>
		/// <param name="roleToEdit">Id from Role</param>
		/// <returns>Return actionresult</returns>
		[HttpPost]
		[Authorize]
		public IActionResult Update(RoleViewModel model)
		{
			var selectedRole = roleRep.RetrieveRoleById(model.roleId);

			if (selectedRole.RetrieveRoleId() != 0)
			{
				var newRole = new Role(selectedRole.RetrieveRoleId(), model.roleName, model.roleDescription);
				roleRep.UpdateRoleById(newRole);
				return RedirectToAction("Overview", "Role");
			}

			return RedirectToAction("Overview", "Role");
		}


		/// <summary>
		///     Insert roles into user
		/// </summary>
		/// <param name="listOfRoles">List of IDs from roles</param>
		/// <param name="u">Selected User</param>
		[HttpPost]
		[Authorize]
		public void InsertRolesForUser(List<Role> listOfRoles, User u)
		{
			foreach (var singleRole in listOfRoles)
			{
				var selectedUser = userRep.RetrieveUserById(u.RetrieveUserId());

				if (selectedUser.RetrieveUserId() != 0)
					roleRep.InsertRolesForUser(singleRole.RetrieveRoleId(), selectedUser.RetrieveUserId());
			}
		}

		/// <summary>
		/// Retrieves the roles from a specific user
		/// </summary>
		/// <param name="u">User object</param>
		/// <returns>Returns a list of roles</returns>
		public List<Role> RetrieveRolesFromUser(User u)
		{
			var allRoles = roleRep.RetrieveRolesFromUser(u);
			return allRoles;
		}

	}
}