using Abp.Domain.Entities;
using EventCloud.Creatives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCloud.Core.Entities
{
    public class Tag : Entity<int>
    {
        public Tag()
        {
            Creatives = new List<Creative>();
        }
        public virtual string Name { get; set; }
        //public virtual ICollection<CreativeTag> CreativeTags { get; set; }
        public virtual IList<Creative> Creatives { get; set; }
    }
}
