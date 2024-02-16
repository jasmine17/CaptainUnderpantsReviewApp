namespace CaptainUnderpantsReviewApp.Models
{
    public class Country
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<Owner> owners { get; set; }
    }
}
