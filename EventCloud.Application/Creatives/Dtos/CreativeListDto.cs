using Abp.AutoMapper;
using EventCloud.Core.Entities;
using System;
using System.Collections.Generic;

namespace EventCloud.Creatives
{
    [AutoMapFrom(typeof(Creative))]
    public class CreativeListDto
    {
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int UserId { get; set; }

        public IList<Tag> Tags { get; set; }
        public IList<Chapter> Capters { get; set; }
        public IList<Rate> Rates { get; set; }
        public DateTime CreationTime { get; set; }
    }
}