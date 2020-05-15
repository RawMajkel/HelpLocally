using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using HelpLocally.Services;
using HelpLocally.Web.ViewModels.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages.Identity
{
    public class LoginModel : PageModel
    {
        private readonly IdentityService _identityService;

        [BindProperty(SupportsGet = true)]
        public RegisterViewModel Login { get; set; }

        public LoginModel(IdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!PageContext.ModelState.IsValid)
            {
                var validator = new RegisterViewModelValidator();
                var createCheck = validator.Validate(Login);
                createCheck.AddToModelState(ModelState, nameof(Login));

                return Page();
            }

            var authentication = await _identityService.Authenticate(Login.Login, Login.Password);
            var user = authentication.Item2;
            var role = await _identityService.GetUserRoleAsync(user);

            if (authentication.Item1)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, Login.Login),
                };

                claims.Add(new Claim(ClaimTypes.Role, role.Name));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties());
            }

            return Redirect("/");
        }
    }
}
