using Abp.Domain.Entities;
using EventCloud.Creatives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCloud.Core.Entities
{
    public class Category : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Creative> Creatives { get; set; }
        public virtual string Url { get; set; }
    }
}
