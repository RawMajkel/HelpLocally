using System;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using HelpLocally.Services;
using HelpLocally.Web.ViewModels.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpLocally.Web.Pages.Identity
{
    public class RegisterModel : PageModel
    {
        private readonly IdentityService _identityService;


        [BindProperty(SupportsGet = true)]
        public RegisterViewModel Register { get; set; }


        [BindProperty]
        public Guid SelectedRole { get; set; }
        public SelectList Roles { get; set; }

        public RegisterModel(IdentityService identityService)
        {
            _identityService = identityService;

            var roles = _identityService.GetRolesDictionary();
            Roles = new SelectList(roles, "Key", "Value");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!PageContext.ModelState.IsValid)
            {
                var validator = new RegisterViewModelValidator();
                var createCheck = validator.Validate(Register);
                createCheck.AddToModelState(ModelState, nameof(Register));

                return Page();
            }

            await _identityService.TryRegisterAsync();

            return Redirect("/");
        }
    }
}
