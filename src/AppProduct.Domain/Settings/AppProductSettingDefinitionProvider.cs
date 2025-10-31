using Volo.Abp.Settings;

namespace AppProduct.Settings;

public class AppProductSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AppProductSettings.MySetting1));
    }
}
