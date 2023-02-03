using Ftl.SalesCrm.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Ftl.SalesCrm.Permissions;

public class SalesCrmPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SalesCrmPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SalesCrmPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SalesCrmResource>(name);
    }
}
