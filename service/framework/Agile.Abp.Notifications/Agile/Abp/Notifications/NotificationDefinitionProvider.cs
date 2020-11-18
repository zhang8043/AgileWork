using Volo.Abp.DependencyInjection;

namespace Agile.Abp.Notifications
{
    public abstract class NotificationDefinitionProvider : INotificationDefinitionProvider, ITransientDependency
    {
        public abstract void Define(INotificationDefinitionContext context);
    }
}
