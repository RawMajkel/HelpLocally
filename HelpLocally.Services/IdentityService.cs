using HelpLocally.Domain;
using HelpLocally.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HelpLocally.Services
{
    public class IdentityService
    {
        private readonly HelpLocallyContext _context;

        public IdentityService(HelpLocallyContext context)
        {
            _context = context;
        }

        public async Task<Role[]> GetRolesAsync()
        {
            return await _context.Roles.ToArrayAsync();
        }
    }
}
