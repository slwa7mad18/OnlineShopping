using OnlineShopping.ViewModel.review;

namespace OnlineShopping.Reposatory.ReviewReprositry
{
    public interface IReviewReprositry
    {
        List<ReviewProductNameAndNoFReviewViewModel> GetAllProductThatHaveRevies();
        List<GetReviewsViewModel> GetReviewsOnSpecificProduct(int ProductId);

        void Insert(AddReviewDBViewModel addReviewDBViewModel);

    }
}