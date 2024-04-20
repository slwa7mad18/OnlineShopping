﻿
using Microsoft.EntityFrameworkCore;
using OnlineShopping.ViewModel.review;
using WebApplication1.Models;

namespace OnlineShopping.Reposatory.ReviewReprositry
{
    public class ReviewReprositry: IReviewReprositry
    {
        private readonly Context context;

        public ReviewReprositry(Context context)
        {
            this.context = context;
        }
        public List<ReviewProductNameAndNoFReviewViewModel> GetAllProductThatHaveRevies()
        {
            var productThatHaveReviews = context.Products.Where(p => p.Reviews.Count > 0).Include(p => p.Reviews).ToList();
            List<ReviewProductNameAndNoFReviewViewModel> reviews = new List<ReviewProductNameAndNoFReviewViewModel>();
            foreach (var product in productThatHaveReviews)
            {
                reviews.Add(new ReviewProductNameAndNoFReviewViewModel()
                {
                    Id = product.Id,
                    ProductName = product.Name,
                    NumberOfReviews = product.Reviews.Count
                });
            }
            return reviews;
        }

        public List<GetReviewsViewModel> GetReviewsOnSpecificProduct(int ProductId)
        {
            var productReviews = context.reviews.Where(r => r.ProductId == ProductId).Include(r => r.User).ToList();
            var reviews = new List<GetReviewsViewModel>();
            foreach (var productReview in productReviews)
            {
                reviews.Add(new GetReviewsViewModel()
                {
                    UserFullName = productReview.User.FirstName + " " + productReview.User.LastName,
                    Rate = productReview.Rate,
                    Comment = productReview.Comment,
                    AddedDateTime = productReview.AddedDateTime
                });
            }

            return reviews;
        }
        public void Insert(AddReviewDBViewModel addReviewDBViewModel)
        {
            var review = new Review();
            review.Rate = addReviewDBViewModel.Rate;
            review.Comment = addReviewDBViewModel.Comment;
            review.ProductId = addReviewDBViewModel.ProdId;
            review.UserId = addReviewDBViewModel.UserId;

            context.reviews.Add(review);
            context.SaveChanges();

        }
    }
}
