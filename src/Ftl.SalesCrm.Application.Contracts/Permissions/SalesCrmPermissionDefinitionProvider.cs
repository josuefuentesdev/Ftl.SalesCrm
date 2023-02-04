using Ftl.SalesCrm.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Ftl.SalesCrm.Permissions;

public class SalesCrmPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var salesCrmGroup = context.AddGroup(SalesCrmPermissions.GroupName, L("Permission:Crm"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SalesCrmPermissions.MyPermission1, L("Permission:MyPermission1"));
        var contactsPermission = salesCrmGroup.AddPermission(SalesCrmPermissions.Contacts.Default, L("Permission:Contacts"));
        contactsPermission.AddChild(SalesCrmPermissions.Contacts.Create, L("Permission:Contacts.Create"));
        contactsPermission.AddChild(SalesCrmPermissions.Contacts.Edit, L("Permission:Contacts.Edit"));
        contactsPermission.AddChild(SalesCrmPermissions.Contacts.Delete, L("Permission:Contacts.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SalesCrmResource>(name);
    }
}
