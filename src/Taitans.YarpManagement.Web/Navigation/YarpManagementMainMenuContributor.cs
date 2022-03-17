using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Authorization.Permissions;
using Taitans.YarpManagement.Localization;
using Taitans.YarpManagement.Permissions;

namespace Taitans.YarpManagement.Web.Navigation;

public class YarpManagementMainMenuContributor : IMenuContributor
{
    public Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name != StandardMenus.Main)
        {
            return Task.CompletedTask;
        }

        var l = context.GetLocalizer<YarpManagementResource>();

        var yarpManagementMenuItem = new ApplicationMenuItem(
                                            YarpManagementMenuNames.GroupName, 
                                            l["Menu:YarpManagement"],
                                            "~/YarpManagement/ProxyConfigs", 
                                            icon: "fa fa-folder-open")
                                        .RequirePermissions(YarpManagementPermissions.ProxyConfigs.Default);

        context.Menu.AddItem(yarpManagementMenuItem);

        return Task.CompletedTask;
    }
}
