using System;

namespace Agile.Abp.MultiTenancy
{
    public class CreateEventData
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid AdminUserId { get; set; }

        public string AdminEmailAddress { get; set; }

        public string AdminPassword { get; set; }
    }
}
