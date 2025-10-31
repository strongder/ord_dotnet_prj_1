using AppProduct.Localization;
using Volo.Abp.Application.Services;

namespace AppProduct;

/* Inherit your application services from this class.
 */
public abstract class AppProductAppService : ApplicationService
{
    protected AppProductAppService()
    {
        LocalizationResource = typeof(AppProductResource);
    }
}
