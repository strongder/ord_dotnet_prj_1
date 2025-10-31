using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using AppProduct.Localization;

namespace AppProduct.Web;

[Dependency(ReplaceServices = true)]
public class AppProductBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AppProductResource> _localizer;

    public AppProductBrandingProvider(IStringLocalizer<AppProductResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
