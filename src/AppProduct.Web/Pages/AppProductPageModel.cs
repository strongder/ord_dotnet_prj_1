using AppProduct.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AppProduct.Web.Pages;

public abstract class AppProductPageModel : AbpPageModel
{
    protected AppProductPageModel()
    {
        LocalizationResourceType = typeof(AppProductResource);
    }
}
