using BackendAdmin.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BackendAdmin.Permissions
{
    public class BackendAdminPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BackendAdminPermissions.GroupName, L("Permission:BackendAdmin"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BackendAdminResource>(name);
        }
    }
}