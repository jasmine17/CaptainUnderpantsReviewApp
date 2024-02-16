using CaptainUnderpantsReviewApp.Data;
using CaptainUnderpantsReviewApp.Interfaces;
using CaptainUnderpantsReviewApp.Models;

namespace CaptainUnderpantsReviewApp.Repository
{
    public class CaptainUnderpantsRepository: ICaptainUnderpantsRepository
    {
        private readonly DataContext _dataContext;
        public CaptainUnderpantsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CaptainUnderpantExists(int id)
        {
            return _dataContext.CaptainUnderpants.Any(a => a.Id == id);
        }

        public bool CreateCaptainUnderpants(int ownerId, int categoryId, CaptainUnderpant captainUnderpant)
        {
            var captainUnderpantEntity = _dataContext.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _dataContext.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var captainUnderpantOwner = new CaptainUnderpantsOwner()
            {
                Owner = captainUnderpantEntity,
                CaptainUnderpants = captainUnderpant
            };

            _dataContext.Add(captainUnderpantOwner);

            var captainCategory = new CaptainUnderpantsCategory()
            {
                Category = category,
                CaptainUnderpants = captainUnderpant
            };
            _dataContext.Add(captainCategory);

            return Save();
            
        }

        public CaptainUnderpant GetCaptainUnderpant(int id)
        {
            return _dataContext.CaptainUnderpants.Where(p => p.Id == id).FirstOrDefault();
           
        }

        public CaptainUnderpant GetCaptainUnderpant(string name)
        {
            return _dataContext.CaptainUnderpants.Where(c => c.Name == name).FirstOrDefault();
        }

        public decimal GetCaptainUnderpantRating(int id)
        {
            var review=_dataContext.Reviews.Where(c=>c.CaptainUnderpants.Id==id);
            if (review.Count() <= 0)
                return 0;

            return((decimal)review.Sum(r=>r.Rating)/review.Count());
        }

        public ICollection<CaptainUnderpant> GetCaptainUnderpants()
        {
            return _dataContext.CaptainUnderpants.OrderBy(c => c.Id).ToList();
        }

        public bool Save()
        {
           var saved = _dataContext.SaveChanges();
            return saved >0 ?true : false;
        }
    }
}
