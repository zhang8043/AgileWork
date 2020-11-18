namespace BackendAdmin
{
    public static class BackendAdminDbProperties
    {
        public static string DbTablePrefix { get; set; } = "BackendAdmin";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "BackendAdmin";
    }
}
