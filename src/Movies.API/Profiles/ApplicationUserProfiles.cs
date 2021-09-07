using AutoMapper;
using Movies.API.Data.Entities;
using Movies.API.Model.ApplicationUserProfile;

namespace Movies.API.Profiles
{
    public class ApplicationUserMappingProfiles : Profile
    {
        public ApplicationUserMappingProfiles()
        {
            CreateMap<ApplicationUserProfile, ApplicationUserProfileModel>();
        }
    }
}
