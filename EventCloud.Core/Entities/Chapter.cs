using Abp.Domain.Entities;
using EventCloud.Creatives;

namespace EventCloud.Core.Entities
{
    public class Chapter : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual string Content { get; set; }
        public virtual int NumberOfChapter { get; set; }

        public virtual int CreativeId { get; set; }
        public virtual Creative Creative { get; set; }
    }
}