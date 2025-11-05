namespace AppProduct.Permissions;

public static class AppProductPermissions
{
    public const string GroupName = "AppProduct";

    public static class ProductPermissions
    {
        public const string Default = GroupName + ".Product";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string GetPage = Default + ".GetPage";
        public const string Detail = Default + ".Detail";
    }

    public static class CategoryPermissions
    {
        public const string Default = GroupName + ".Category";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string GetPage = Default + ".GetPage";
        public const string Detail = Default + ".ViewOwn";
    }


    public static class UserPermissions
    {
        public const string Default = GroupName + ".User";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string GetPage = Default + ".GetPage";
        public const string Detail = Default + ".ViewOwn";
    }
}
