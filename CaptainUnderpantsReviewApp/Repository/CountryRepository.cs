using CaptainUnderpantsReviewApp.Models;
using CaptainUnderpantsReviewApp.Interfaces;
using CaptainUnderpantsReviewApp.Data;

namespace CaptainUnderpantsReviewApp.Repository
{
   
    public class CountryRepository : ICountryRepository
    {
        private DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(country => country.Id == id);
        }

        public bool CreateCountry(Country country)
        {
           _context.Add(country);
            return Save();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int Ownerid)
        {
            return _context.Owners.Where(o => o.Id == Ownerid).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >0 ? true: false;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return Save();
        }
    }
}
