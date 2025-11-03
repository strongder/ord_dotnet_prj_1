using System;
using Volo.Abp.Identity;


namespace AppProduct.Entity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }

}
