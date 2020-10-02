using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Cows
{
    public class Cow : Entity<int>, IHasCreationTime
    {
        public string State { get; set; }
        public string FarmId { get; set; }
        public DateTime CreationTime { get; set; }

        public Cow()
        {
            CreationTime = Clock.Now;
        }
    }
}
