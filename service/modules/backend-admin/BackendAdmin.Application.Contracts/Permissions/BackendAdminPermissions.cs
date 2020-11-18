using Volo.Abp.Reflection;

namespace BackendAdmin.Permissions
{
    public class BackendAdminPermissions
    {
        public const string GroupName = "BackendAdmin";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(BackendAdminPermissions));
        }
    }
}