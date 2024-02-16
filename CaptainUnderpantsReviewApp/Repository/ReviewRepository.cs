using CaptainUnderpantsReviewApp.Data;
using CaptainUnderpantsReviewApp.Interfaces;
using CaptainUnderpantsReviewApp.Models;

namespace CaptainUnderpantsReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private DataContext _dataContext;

        public ReviewRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateReview(Review review)
        {
            _dataContext.Add(review);
            return Save();
        }

        public Review GetReview(int reviewId)
        {
            return _dataContext.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _dataContext.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfACaptainUnderpants(int captainId)
        {
            return _dataContext.Reviews.Where(r => r.CaptainUnderpants.Id == captainId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _dataContext.Reviews.Any(r => r.Id == reviewId);
        }

        public bool Save()
        {
             var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
