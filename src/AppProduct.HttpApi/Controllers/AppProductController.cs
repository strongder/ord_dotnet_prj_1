using AppProduct.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AppProduct.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AppProductController : AbpControllerBase
{
    protected AppProductController()
    {
        LocalizationResource = typeof(AppProductResource);
    }
}
