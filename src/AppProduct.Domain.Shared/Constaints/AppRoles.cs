using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Constaints
{
    internal class AppRoles
    {

        public const string Admin = "Admin";
        public const string ShopManager = "ShopManager";
        public const string User = "User";

        public static readonly string[] AllRoles = new string[]
        {
            Admin,
            ShopManager,
            User
        };
    }
}
