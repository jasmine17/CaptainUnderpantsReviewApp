namespace CaptainUnderpantsReviewApp.Models
{
    public class CaptainUnderpantsOwner
    {
        public int CaptainUnderpantsId { get; set; }
        public int OwnerId { get; set; }
        public CaptainUnderpant CaptainUnderpants { get; set; }
        public Owner Owner { get; set; }
    }
}
