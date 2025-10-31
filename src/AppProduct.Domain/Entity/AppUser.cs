using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace AppProduct.Entity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
