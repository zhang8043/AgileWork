using System.Collections.Generic;

namespace Agile.Abp.Notifications
{
    public interface INotificationPublishProviderManager
    {
        List<INotificationPublishProvider> Providers { get; }
    }
}
