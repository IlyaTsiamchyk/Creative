using Abp.Domain.Entities;
using EventCloud.Creatives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCloud.Core.Entities
{
    public class Comment : Entity<int>
    {
        public virtual string CommentText { get; set; }
        public virtual DateTime DatePosted { get; set; }

        public virtual int CreativeId { get; set; }
        public virtual Creative Creative { get; set; }
    }
}
