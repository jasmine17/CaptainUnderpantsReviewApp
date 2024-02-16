namespace CaptainUnderpantsReviewApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CaptainUnderpantsCategory> CaptainUnderpantsCategories { get; set; }  
    }
}
