using AppProduct.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace AppProduct.Permissions;

public class AppProductPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var group = context.AddGroup(AppProductPermissions.GroupName, L("Permission:AppProduct"));

        var product = group.AddPermission(AppProductPermissions.ProductPermissions.Default, L("Permission:Product"));
        product.AddChild(AppProductPermissions.ProductPermissions.Create, L("Permission:Create"));
        product.AddChild(AppProductPermissions.ProductPermissions.Edit, L("Permission:Edit"));
        product.AddChild(AppProductPermissions.ProductPermissions.Delete, L("Permission:Delete"));
        product.AddChild(AppProductPermissions.ProductPermissions.GetPage, L("Permission:GetPage"));
        product.AddChild(AppProductPermissions.ProductPermissions.Detail, L("Permission:Detail"));

        var category = group.AddPermission(AppProductPermissions.CategoryPermissions.Default, L("Permission:Category"));
        category.AddChild(AppProductPermissions.CategoryPermissions.Create, L("Permission:Create"));
        category.AddChild(AppProductPermissions.CategoryPermissions.Edit, L("Permission:Edit"));
        category.AddChild(AppProductPermissions.CategoryPermissions.Delete, L("Permission:Delete"));
        category.AddChild(AppProductPermissions.CategoryPermissions.GetPage, L("Permission:GetPage"));
        category.AddChild(AppProductPermissions.CategoryPermissions.Detail, L("Permission:Detail"));

        var user = group.AddPermission(AppProductPermissions.UserPermissions.Default, L("Permission:User"));
        user.AddChild(AppProductPermissions.UserPermissions.Create, L("Permission:Create"));
        user.AddChild(AppProductPermissions.UserPermissions.Edit, L("Permission:Edit"));
        user.AddChild(AppProductPermissions.UserPermissions.Delete, L("Permission:Delete"));
        user.AddChild(AppProductPermissions.UserPermissions.GetPage, L("Permission:GetPage"));
        user.AddChild(AppProductPermissions.UserPermissions.Detail, L("Permission:Detail"));
    }

    private static LocalizableString L(string name) =>
        LocalizableString.Create<AppProductResource>(name);
}
