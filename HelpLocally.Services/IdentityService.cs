using HelpLocally.Domain;
using HelpLocally.Infrastructure;
using Microsoft.EntityFrameworkCore;
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

        public async Task TryRegisterAsync(string userLogin, string userPassword, Guid userRole)
        {
            if (!await _context.Users.AnyAsync(x => x.Login == userLogin))
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(userPassword);
                var user = new User(userLogin, passwordHash);

                await _context.Users.AddAsync(user);
                await _context.UserRoles.AddAsync(new UserRole { RoleId = userRole, UserId = user.Id });

                await _context.SaveChangesAsync();
            }

            // no user in db
        }

        public async Task<(bool, User)> Authenticate(string userLogin, string userPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == userLogin);

            if (user is { })
            {
                if(BCrypt.Net.BCrypt.Verify(userPassword, user.PasswordHash))
                {
                    return (true, user);
                }
            }
            return (false, null); // no user in db
        }

        public async Task<Role> GetUserRoleAsync(User user)
        {
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.Id);
            return await _context.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
        }
    }
}
