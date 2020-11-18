namespace Agile.Abp.Notifications
{
    public interface INotificationDefinitionProvider
    {
        void Define(INotificationDefinitionContext context);
    }
}
