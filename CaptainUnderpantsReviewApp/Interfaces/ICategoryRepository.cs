using CaptainUnderpantsReviewApp.Models;
namespace CaptainUnderpantsReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<CaptainUnderpant> GetCaptainUnderpantByCategory(int categoryId);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool CategoryExists(int id);
        bool Save();
    }
}
