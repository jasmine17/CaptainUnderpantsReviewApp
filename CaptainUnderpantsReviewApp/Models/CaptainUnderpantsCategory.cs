namespace CaptainUnderpantsReviewApp.Models
{
    public class CaptainUnderpantsCategory
    {
        public int CaptainUnderpantsId { get; set; }
        public int CategoryId { get; set; }

        public CaptainUnderpant CaptainUnderpants { get; set; }

        public Category Category { get; set; }
    }
}
