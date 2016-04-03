using Abp.Domain.Entities;
using EventCloud.Creatives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventCloud.Core.Entities
{
    public class Rate : Entity<int>
    {
        public virtual double Value { get; set; }
        public virtual int UserBy { get; set; }

        public virtual int CreativeId { get; set; }
        public virtual Creative Creative { get; set; }
    }
}