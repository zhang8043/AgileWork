using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agile.Abp.Notifications
{
    public interface INotificationPublishProvider
    {
        string Name { get; }

        Task PublishAsync(NotificationInfo notification, IEnumerable<UserIdentifier> identifiers);
    }
}
