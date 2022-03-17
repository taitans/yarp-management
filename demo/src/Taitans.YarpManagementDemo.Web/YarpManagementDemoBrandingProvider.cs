using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Taitans.YarpManagementDemo.Web;

[Dependency(ReplaceServices = true)]
public class YarpManagementDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "YarpManagementDemo";
}
