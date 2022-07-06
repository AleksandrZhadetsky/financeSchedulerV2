using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User
{
    public class AppUser : IdentityUser
    {
        public double Balance { get; private set; }

        public AppUser()
        {
        }

        public AppUser(double balance)
        {
            Balance = balance;
        }

        public AppUser(string email, string username, double balance) : this(balance)
        {
            Email = email;
            UserName = username;
        }

        public AppUser(string email, string userName, double balance, string securityStamp) : this(email, userName, balance)
        {
            SecurityStamp = securityStamp;
        }
    }
}
