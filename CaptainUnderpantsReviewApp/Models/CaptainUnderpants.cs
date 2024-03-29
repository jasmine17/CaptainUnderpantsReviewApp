﻿namespace CaptainUnderpantsReviewApp.Models
{
    public class CaptainUnderpant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<CaptainUnderpantsOwner> CaptainUnderpantsOwners { get; set; }
        public ICollection<CaptainUnderpantsCategory> CaptainUnderpantsCategories { get; set; }
    }
}
