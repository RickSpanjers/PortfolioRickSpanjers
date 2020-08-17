using PortfolioRick.Interface;
using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Repositories
{
    public class ReviewRepository
    {
		private readonly IReview reviewInterface;

		public ReviewRepository(IReview context)
		{
			reviewInterface = context;
		}

		public bool CreateNewReview(Review r)
		{
			return reviewInterface.CreateNewReview(r);
		}

		public List<Review> RetrieveAllReviews()
		{
			return reviewInterface.RetrieveAllReviews();
		}

		public bool DeleteReviewById(int Id)
		{
			return reviewInterface.DeleteReviewById(Id);
		}

		public bool UpdateReviewById(Review r)
		{
			return reviewInterface.UpdateReviewById(r);
		}

		public Review RetrieveReviewById(int id)
		{
			return reviewInterface.RetrieveReviewById(id);
		}
	}
}
