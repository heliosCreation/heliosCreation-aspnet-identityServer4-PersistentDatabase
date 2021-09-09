using IdentityModel;
using IdentityServer.Entities;
using IdentityServer.Quickstart.UserRegistration;
using IdentityServer.Services;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer.UserRegistration
{
    public class UserRegistrationController : Controller
    {
        private readonly ILocalUserService _localUserService;
        private readonly IIdentityServerInteractionService _identityServerInteractionService;

        public UserRegistrationController(
            ILocalUserService localUserService,
            IIdentityServerInteractionService identityServerInteractionService)
        {
            _localUserService = localUserService;
            _identityServerInteractionService = identityServerInteractionService;
        }

        [HttpGet]
        public IActionResult RegisterUser(string returnUrl)
        {
            return View(new RegisterUserViewModel() { ReturnUrl = returnUrl });
        }

        [HttpGet]
        public async Task<IActionResult> ActivateUser(string securityCode, string returnUrl)
        {
            if (await _localUserService.ActivateUser(securityCode))
            {
                ViewData["Message"] = "Congratulation, you are now registered with us.";
                ViewData["returnUrl"] = returnUrl;
            }
            else
            {
                ViewData["Message"] = "Something went wrong while validating your request. Click here to resend an activation link.";
            }

            await _localUserService.SaveChangesAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userToCreate = new User
            {
                Subject = Guid.NewGuid().ToString(),
                Username = model.Username,
                Email = model.Email,
                IsActive = false
            };
            userToCreate.Claims.Add(new UserClaim()
            {
                Type = "country",
                Value = model.Country
            });

            userToCreate.Claims.Add(new UserClaim()
            {
                Type = JwtClaimTypes.Address,
                Value = model.Address
            });

            userToCreate.Claims.Add(new UserClaim()
            {
                Type = JwtClaimTypes.GivenName,
                Value = model.GivenName
            });

            userToCreate.Claims.Add(new UserClaim()
            {
                Type = JwtClaimTypes.FamilyName,
                Value = model.FamilyName
            });

            _localUserService.AddUser(userToCreate, model.Password);
            await _localUserService.SaveChangesAsync();

            var identity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(JwtClaimTypes.Subject, userToCreate.Subject),
                new Claim(JwtClaimTypes.Name, userToCreate.Username)
            }, "custom");
            var principal = new ClaimsPrincipal(identity);

            var link = Url.ActionLink("ActivateUser", "UserRegistration", new { securityCode = userToCreate.SecurityCode, returnUrl = model.ReturnUrl });

            //TODO Send link via email
            Debug.WriteLine(link);


            //// log the user in
            //await HttpContext.SignInAsync(principal);

            //// continue with the flow     
            //if (_identityServerInteractionService.IsValidReturnUrl(model.ReturnUrl)
            //    || Url.IsLocalUrl(model.ReturnUrl))
            //{
            //    return Redirect(model.ReturnUrl);
            //}

            return View("ActivationCodeSent");
        }
    }
}
