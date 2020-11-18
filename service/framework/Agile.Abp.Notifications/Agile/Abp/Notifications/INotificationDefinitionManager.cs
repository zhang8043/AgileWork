using JetBrains.Annotations;
using System.Collections.Generic;

namespace Agile.Abp.Notifications
{
    public interface INotificationDefinitionManager
    {
        [NotNull]
        NotificationDefinition Get([NotNull] string name);

        IReadOnlyList<NotificationDefinition> GetAll();

        NotificationDefinition GetOrNull(string name);

        IReadOnlyList<NotificationGroupDefinition> GetGroups();
    }
}
