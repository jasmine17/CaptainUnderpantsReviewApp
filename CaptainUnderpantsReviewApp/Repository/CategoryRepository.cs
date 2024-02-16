using CaptainUnderpantsReviewApp.Data;
using CaptainUnderpantsReviewApp.Interfaces;
using CaptainUnderpantsReviewApp.Models;

namespace CaptainUnderpantsReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
       
        private DataContext _context;

        public CategoryRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<CaptainUnderpant> GetCaptainUnderpantByCategory(int categoryId)
        {
            return _context.CaptainUnderpantsCategories.Where(e => e.CategoryId == categoryId).Select(c => c.CaptainUnderpants).ToList();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
                
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
