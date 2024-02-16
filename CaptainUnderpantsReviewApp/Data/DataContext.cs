using CaptainUnderpantsReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CaptainUnderpantsReviewApp.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries   { get; set; }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<CaptainUnderpant> CaptainUnderpants { get; set; }
        public DbSet<CaptainUnderpantsOwner> CaptainUnderpantsOwners { get; set; }

        public DbSet<CaptainUnderpantsCategory> CaptainUnderpantsCategories { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaptainUnderpantsCategory>()
                .HasKey(pc => new { pc.CaptainUnderpantsId, pc.CategoryId });
            modelBuilder.Entity<CaptainUnderpantsCategory>()
                .HasOne(p => p.CaptainUnderpants)
                .WithMany(pc => pc.CaptainUnderpantsCategories)
                .HasForeignKey(p => p.CaptainUnderpantsId);
            modelBuilder.Entity<CaptainUnderpantsCategory>()
               .HasOne(p => p.Category)
               .WithMany(pc => pc.CaptainUnderpantsCategories)
               .HasForeignKey(c => c.CategoryId);


            modelBuilder.Entity<CaptainUnderpantsOwner>()
                    .HasKey(po => new { po.CaptainUnderpantsId, po.OwnerId });
            modelBuilder.Entity<CaptainUnderpantsOwner>()
                    .HasOne(p => p.CaptainUnderpants)
                    .WithMany(pc => pc.CaptainUnderpantsOwners)
                    .HasForeignKey(p => p.CaptainUnderpantsId);
            modelBuilder.Entity<CaptainUnderpantsOwner>()
                    .HasOne(p => p.Owner)
                    .WithMany(pc => pc.CaptainUnderpantsOwners)
                    .HasForeignKey(c => c.OwnerId);
        } 
    }
}
