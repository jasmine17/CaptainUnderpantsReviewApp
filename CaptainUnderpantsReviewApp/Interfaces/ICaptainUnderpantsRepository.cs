using CaptainUnderpantsReviewApp.Models;

namespace CaptainUnderpantsReviewApp.Interfaces
{
    public interface ICaptainUnderpantsRepository
    {
        ICollection<CaptainUnderpant> GetCaptainUnderpants();

        CaptainUnderpant GetCaptainUnderpant(int id);

        CaptainUnderpant GetCaptainUnderpant(string name);

        decimal GetCaptainUnderpantRating(int id);
        bool CaptainUnderpantExists(int id);

        bool CreateCaptainUnderpants(int ownerId, int categoryId, CaptainUnderpant captainUnderpant);

        bool Save();
    }
}
