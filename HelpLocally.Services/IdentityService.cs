using HelpLocally.Domain;
using HelpLocally.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Role[] GetRoles()
        {
            return _context.Roles.ToArray();
        }

        public Dictionary<Guid, string> GetRolesDictionary()
        {
            return _context.Roles.ToDictionary(y => y.Id, x => x.Name);
        }

        public async Task TryRegisterAsync(string login = null)
        {
            //return await _context.Users.AnyAsync(x => x.Login == login);
        }
    }
}
