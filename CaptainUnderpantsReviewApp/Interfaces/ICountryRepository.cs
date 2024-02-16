using CaptainUnderpantsReviewApp.Models;
namespace CaptainUnderpantsReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();

        Country GetCountry(int id);

        Country GetCountryByOwner(int Ownerid);

        ICollection<Owner> GetOwnersFromCountry(int countryId);

        bool CountryExists(int id);

        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool Save();
    }
}
