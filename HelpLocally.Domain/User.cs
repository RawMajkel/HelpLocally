using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLocally.Domain
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        //public virtual ICollection<Voucher> Vouchers { get; set; }

        public User(string login, string passwordHash)
        {
            Login = login;
            PasswordHash = passwordHash;
        }
    }
}
