using System;
using Volo.Abp.Identity;


namespace AppProduct.Entity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public AppUser()
        {
        }


        public AppUser(string userName, string email = null) : base(Guid.NewGuid(), userName, email)
        {
        }
    }

}
