using AutoMapper;
using CaptainUnderpantsReviewApp.Dto;
using CaptainUnderpantsReviewApp.Models;

namespace CaptainUnderpantsReviewApp.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<CaptainUnderpant, CaptainUnderpantDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Country,CountryDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<CaptainUnderpantDto, CaptainUnderpant>();
            CreateMap<ReviewDto, Review>();
            CreateMap<ReviewerDto, Reviewer>();
            CreateMap<Reviewer, ReviewerDto>();
          
            CreateMap<Owner, OwnerDto>();
            CreateMap<Review, ReviewDto>();
         
        }


    }
}
