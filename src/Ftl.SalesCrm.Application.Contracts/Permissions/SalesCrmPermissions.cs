namespace Ftl.SalesCrm.Permissions;

public static class SalesCrmPermissions
{
    public const string GroupName = "SalesCrm";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public static class Contacts
    {
        public const string Default = GroupName + ".Contacts";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}