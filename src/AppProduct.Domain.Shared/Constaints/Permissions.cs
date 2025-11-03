using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Constaints
{
    internal class Permissions
    {
        public const string GroupName = "AppProduct";
        public static class ProductPermissions
        {
            public const string Default = GroupName +  "Product";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
            public const string ViewAll = Default + ".ViewAll";
            public const string ViewOwn = Default + ".ViewOwn";
        }

        public static class CategoryPermissions
        {
            public const string Default = GroupName + "Category";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
            public const string ViewAll = Default + ".ViewAll";
            public const string ViewOwn = Default + ".ViewOwn";
        }


        public static class UserPermissions
        {
            public const string Default = GroupName + "User";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
            public const string ViewAll = Default + ".ViewAll";
            public const string ViewOwn = Default + ".ViewOwn";
        }
    }
}
