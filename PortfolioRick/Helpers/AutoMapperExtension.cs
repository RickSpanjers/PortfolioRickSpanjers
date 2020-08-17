using AutoMapper;
using PortfolioRick.Models;
using PortfolioRick.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Helpers
{
    public class AutoMapperExtension
    {
		public static void Initialize()
		{
			Mapper.Initialize(cfg => {

			});
		}

		public IMapper BlogToBlogItemViewModel()
		{
			var map = new MapperConfiguration(cfg => cfg.CreateMap<BlogItem, BlogItemViewModel>()
			.ForMember(dest => dest.itemId, opt => opt.MapFrom(src => src.RetrieveId()))
			.ForMember(dest => dest.itemTitle, opt => opt.MapFrom(src => src.RetrieveTitle()))
			.ForMember(dest => dest.itemMessage, opt => opt.MapFrom(src => src.RetrieveMessage()))
			.ForMember(dest => dest.published, opt => opt.MapFrom(src => src.Publised))
			.ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(src => src.Thumbnail))
			.ForMember(dest => dest.createdDate, opt => opt.MapFrom(src => src.CreatedDate)));
			var mapper = map.CreateMapper();
			return mapper;
		}

		public IMapper PortfolioItemToPortfolioItemViewModel()
		{
			var map = new MapperConfiguration(cfg => cfg.CreateMap<PortfolioItem, PortfolioItemViewModel>()
			.ForMember(dest => dest.itemId, opt => opt.MapFrom(src => src.RetrieveId()))
			.ForMember(dest => dest.categoryName, opt => opt.MapFrom(src => src.categoryName))
			.ForMember(dest => dest.itemTitle, opt => opt.MapFrom(src => src.RetrieveTitle()))
			.ForMember(dest => dest.itemDesc, opt => opt.MapFrom(src => src.RetrieveDescription()))
			.ForMember(dest => dest.createdDate, opt => opt.MapFrom(src => src.createdDate))
			.ForMember(dest => dest.FrontpageImg, opt => opt.MapFrom(src => src.FrontpageImg))
			.ForMember(dest => dest.urlLink, opt => opt.MapFrom(src => src.urlLink))
			.ForMember(dest => dest.urlTitle, opt => opt.MapFrom(src => src.urlTitle)));
			var mapper = map.CreateMapper();
			return mapper;
		}

		public IMapper ReviewToReviewItemViewModel()
		{
			var map = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewItemViewModel>()
			.ForMember(dest => dest.reviewId, opt => opt.MapFrom(src => src.RetrieveId()))
			.ForMember(dest => dest.reviewMessage, opt => opt.MapFrom(src => src.RetrieveMessage()))
			.ForMember(dest => dest.reviewName, opt => opt.MapFrom(src => src.RetrieveName())));
			var mapper = map.CreateMapper();
			return mapper;
		}

		public IMapper RoleToRoleOverviewViewModel()
		{
			var map = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleOverviewViewModel>()
			.ForMember(dest => dest.roleId, opt => opt.MapFrom(src => src.RetrieveRoleId()))
			.ForMember(dest => dest.roleName, opt => opt.MapFrom(src => src.RetrieveRoleName()))
			.ForMember(dest => dest.roleDescription, opt => opt.MapFrom(src => src.RetrieveDescription()))
			.ForMember(dest => dest.listofRoles, opt => opt.Ignore()));
			var mapper = map.CreateMapper();
			return mapper;
		}

		public IMapper RoleToRoleViewModel()
		{
			var map = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleViewModel>()
			.ForMember(dest => dest.roleId, opt => opt.MapFrom(src => src.RetrieveRoleId()))
			.ForMember(dest => dest.roleName, opt => opt.MapFrom(src => src.RetrieveRoleName()))
			.ForMember(dest => dest.roleDescription, opt => opt.MapFrom(src => src.RetrieveDescription())));
			var mapper = map.CreateMapper();
			return mapper;
		}

		public IMapper UserToUserViewModel()
		{
			var map = new MapperConfiguration(cfg => cfg.CreateMap<User, UserViewModel>()
			.ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.RetrieveUserId()))
			.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
			.ForMember(dest => dest.emailAddress, opt => opt.MapFrom(src => src.Email))
			.ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Firstname))
			.ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Lastname))
			.ForMember(dest => dest.password, opt => opt.MapFrom(src => src.Password))
			.ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
			.ForMember(dest => dest.Zipcode, opt => opt.MapFrom(src => src.Zipcode))
			.ForMember(dest => dest.username, opt => opt.MapFrom(src => src.Username))
			.ForMember(dest => dest.role, opt => opt.Ignore()));

			var mapper = map.CreateMapper();
			return mapper;
		}
	}
}
