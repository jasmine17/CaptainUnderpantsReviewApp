using CaptainUnderpantsReviewApp.Data;
using CaptainUnderpantsReviewApp.Models;
namespace CaptainUnderpantsReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.CaptainUnderpantsOwners.Any())
            {
                var CaptainUnderpantsOwners = new List<CaptainUnderpantsOwner>()
                {
                    new CaptainUnderpantsOwner()
                    {
                        CaptainUnderpants = new CaptainUnderpant()
                        {
                            Name = "CaptainUnderpant",
                            BirthDate = new DateTime(1903,1,1),
                            CaptainUnderpantsCategories = new List<CaptainUnderpantsCategory>()
                            {
                                new CaptainUnderpantsCategory { Category = new Category() { Name = "Electric"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="George Beard",Text = "George Beard is a fourth grader at Jerome Horwitz Elementary School", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Jasmine", LastName = "Merchant" } },
                                new Review { Title="Harold Hutchins", Text = "Harold Hutchins is one of the main characters in the series", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Nadeem", LastName = "Lalani" } },
                                new Review { Title="Mr. Krupp",Text = "Benjamin Krupp is the principal of Jerome Horwitz Elementary School", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Ayan", LastName = "Lalani" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Jasmine",
                            LastName = "Merchant",
                            Gym = "Brocks Gym",
                            Country = new Country()
                            {
                                Name = "India"
                            }
                        }
                    },
                    new CaptainUnderpantsOwner()
                    {
                        CaptainUnderpants = new CaptainUnderpant()
                        {
                            Name = "CaptainUnderpant",
                            BirthDate = new DateTime(1903,1,1),
                            CaptainUnderpantsCategories = new List<CaptainUnderpantsCategory>()
                            {
                                new CaptainUnderpantsCategory { Category = new Category() { Name = "Water"}}
                            },
                            Reviews = new List<Review>()
                            {
                                 new Review { Title="George Beard",Text = "George Beard is a fourth grader at Jerome Horwitz Elementary School", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Jasmine", LastName = "Merchant" } },
                                new Review { Title="Harold Hutchins", Text = "Harold Hutchins is one of the main characters in the series", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Nadeem", LastName = "Lalani" } },
                                new Review { Title="Mr. Krupp",Text = "Benjamin Krupp is the principal of Jerome Horwitz Elementary School", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Ayan", LastName = "Lalani" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Harry",
                            LastName = "Potter",
                            Gym = "Mistys Gym",
                            Country = new Country()
                            {
                                Name = "Saffron City"
                            }
                        }
                    },
                                    new CaptainUnderpantsOwner()
                    {
                        CaptainUnderpants = new CaptainUnderpant()
                        {
                            Name = "Venasuar",
                            BirthDate = new DateTime(1903,1,1),
                            CaptainUnderpantsCategories = new List<CaptainUnderpantsCategory>()
                            {
                                new CaptainUnderpantsCategory { Category = new Category() { Name = "Leaf"}}
                            },
                            Reviews = new List<Review>()
                            {
                                 new Review { Title="George Beard",Text = "George Beard is a fourth grader at Jerome Horwitz Elementary School", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Jasmine", LastName = "Merchant" } },
                                new Review { Title="Harold Hutchins", Text = "Harold Hutchins is one of the main characters in the series", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Nadeem", LastName = "Lalani" } },
                                new Review { Title="Mr. Krupp",Text = "Benjamin Krupp is the principal of Jerome Horwitz Elementary School", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Ayan", LastName = "Lalani" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Ash",
                            LastName = "Ketchum",
                            Gym = "Ashs Gym",
                            Country = new Country()
                            {
                                Name = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.CaptainUnderpantsOwners.AddRange(CaptainUnderpantsOwners);
                dataContext.SaveChanges();
            }
        }
    }
}