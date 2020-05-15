using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages.Identity
{
    public class RegisterModel : PageModel
    {
        private readonly IdentityService _identityService;
        public Role[] Roles { get; set; }

        public RegisterModel(IdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task OnGetAsync()
        {
            Roles = await _identityService.GetRolesAsync();
        }
    }
}
