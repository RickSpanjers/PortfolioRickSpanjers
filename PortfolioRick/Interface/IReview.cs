using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Interface
{
    public interface IReview
    {
		bool CreateNewReview(Review r);
		List<Review> RetrieveAllReviews();
		bool DeleteReviewById(int Id);
		bool UpdateReviewById(Review r);
		Review RetrieveReviewById(int id);
	}
}
