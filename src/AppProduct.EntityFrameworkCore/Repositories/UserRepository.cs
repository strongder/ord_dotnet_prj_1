using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace AppProduct.Repositories
{
    public class UserRepository
    {
        private readonly IdentityUserManager _userManager;

        public UserRepository(IdentityUserManager userManager)
        {
            _userManager = userManager;
        }
    }
}
