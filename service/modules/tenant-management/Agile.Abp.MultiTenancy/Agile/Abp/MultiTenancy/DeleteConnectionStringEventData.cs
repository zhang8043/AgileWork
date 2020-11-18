using System;

namespace Agile.Abp.MultiTenancy
{
    public class DeleteConnectionStringEventData
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
