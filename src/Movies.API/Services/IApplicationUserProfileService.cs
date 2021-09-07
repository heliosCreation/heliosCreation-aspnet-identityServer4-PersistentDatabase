using Movies.API.Data.Entities;
using System.Collections.Generic;

namespace Movies.API.Services
{
    public interface IApplicationUserProfileService
    {
        void AddApplicationUserProfile(ApplicationUserProfile applicationUserProfile);
        bool ApplicationUserProfileExists(string subject);
        IReadOnlyList<ApplicationUserProfile> GetAllApplicationUserProfile();
        ApplicationUserProfile GetApplicationUserProfile(string subject);
    }
}