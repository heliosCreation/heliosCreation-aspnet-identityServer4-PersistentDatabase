using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Data.Entities;
using Movies.API.Model.ApplicationUserProfile;
using Movies.API.Services;
using System;
using System.Collections.Generic;

namespace Movies.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    //[Authorize]
    public class ApplicationUserProfilesController : ControllerBase
    {
        private readonly IApplicationUserProfileService _applicationUserProfileService;
        private readonly IMapper _mapper;

        public ApplicationUserProfilesController(
            IApplicationUserProfileService applicationUserProfileService,
            IMapper mapper)
        {
            _applicationUserProfileService = applicationUserProfileService ??
                throw new ArgumentNullException(nameof(applicationUserProfileService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        //[Authorize(Policy = "SubjectMustMatchUser")]
        [HttpGet("{subject}")]
        public IActionResult GetApplicationUserProfile(string subject)
        {
            var applicationUserProfileFromRepo = _applicationUserProfileService.GetApplicationUserProfile(subject);

            if (applicationUserProfileFromRepo == null)
            {
                applicationUserProfileFromRepo = new ApplicationUserProfile
                {
                    Subject = subject,
                    SubscriptionLevel = "freeUser",
                    Role = "user"
                };
                _applicationUserProfileService.AddApplicationUserProfile(applicationUserProfileFromRepo);
            }

            return Ok(_mapper.Map<ApplicationUserProfileModel>(applicationUserProfileFromRepo));
        }

        [HttpGet]
        public IActionResult GetAllApplicationUserProfiles()
        {
            var applicationUserProfileFromRepo = _applicationUserProfileService.GetAllApplicationUserProfile();
            return Ok(_mapper.Map<List<ApplicationUserProfileModel>>(applicationUserProfileFromRepo));
        }


    }

}
