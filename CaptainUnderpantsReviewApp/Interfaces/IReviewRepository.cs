using CaptainUnderpantsReviewApp.Models;

namespace CaptainUnderpantsReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfACaptainUnderpants(int captainId);

        bool ReviewExists(int reviewId);

        bool CreateReview(Review review);
        bool Save();

    }
}
