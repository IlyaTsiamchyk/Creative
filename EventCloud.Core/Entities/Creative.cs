using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using EventCloud.Core.Entities;
using EventCloud.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCloud.Creatives
{
    public class Creative : Entity<int>, IHasCreationTime
    {
        public virtual string Title { get; set; }

        public virtual string Url { get; set; }

        public virtual long UserId { get; set; }
        public virtual User User { get; set; }

        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        //public virtual ApplicationUser User { get; set; }
        //public ICollection<CreativeTag> CreativeTags { get; set; }
        public virtual IList<Tag> Tags { get; set; }
        public virtual IList<Chapter> Capters { get; set; }
        public virtual IList<Rate> Rates { get; set; }

        public virtual DateTime CreationTime { get; set; }
    }
}
