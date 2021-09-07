using Movies.API.Data;
using Movies.API.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.API.Services
{
    public class ApplicationUserProfileService : IApplicationUserProfileService
    {
        private readonly MoviesContext _context;

        public ApplicationUserProfileService(MoviesContext context)
        {
            _context = context;
        }

        public IReadOnlyList<ApplicationUserProfile> GetAllApplicationUserProfile()
        {
            return _context.ApplicationUserProfiles.ToList();
        }
        public ApplicationUserProfile GetApplicationUserProfile(string subject)
        {
            return _context.ApplicationUserProfiles.FirstOrDefault(a => a.Subject == subject);
        }

        public bool ApplicationUserProfileExists(string subject)
        {
            return _context.ApplicationUserProfiles.Any(a => a.Subject == subject);
        }

        public void AddApplicationUserProfile(ApplicationUserProfile applicationUserProfile)
        {
            _context.ApplicationUserProfiles.Add(applicationUserProfile);
        }
    }
}
