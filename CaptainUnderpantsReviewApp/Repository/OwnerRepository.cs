using CaptainUnderpantsReviewApp.Data;
using CaptainUnderpantsReviewApp.Interfaces;
using CaptainUnderpantsReviewApp.Models;

namespace CaptainUnderpantsReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _dataContext;
        public OwnerRepository(DataContext context)
        {
            _dataContext = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _dataContext.Add(owner);
            return Save();
        }

        public ICollection<CaptainUnderpant> GetCaptainUnderpantsByOwner(int ownerId)
        {
            return _dataContext.CaptainUnderpantsOwners.Where(o => o.Owner.Id == ownerId).Select(c => c.CaptainUnderpants).ToList();

        }

        public Owner GetOwner(int ownerId)
        {
            return _dataContext.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfACaptainUnderpants(int captainId)
        {
           return _dataContext.CaptainUnderpantsOwners.Where(c=>c.CaptainUnderpants.Id ==captainId).Select(o=>o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _dataContext.Owners.ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _dataContext.Owners.Any(o => o.Id == ownerId);
        }

        public bool Save()
        {
           var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _dataContext.Update(owner);
            return Save();
        }
    }
}
