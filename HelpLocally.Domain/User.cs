namespace HelpLocally.Domain
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        //public virtual ICollection<Voucher> Vouchers { get; set; }

        public User(string userName, string passwordHash, string role)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
