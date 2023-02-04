using System.Threading.Tasks;
using Ftl.SalesCrm.Localization;
using Ftl.SalesCrm.MultiTenancy;
using Ftl.SalesCrm.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Ftl.SalesCrm.Web.Menus;

public class SalesCrmMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<SalesCrmResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                SalesCrmMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Contacts",
                    l["Menu:Contacts"],
                    icon: "fas fa-address-book"
                ).AddItem(
                new ApplicationMenuItem(
                        "Contacts.Contacts",
                        l["Menu:Contacts"],
                        url: "/Contacts"
                    ).RequirePermissions(SalesCrmPermissions.Contacts.Default)
                )
           );





        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}
