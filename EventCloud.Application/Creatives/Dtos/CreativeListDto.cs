using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EventCloud.Core.Entities;
using EventCloud.Creatives;
using System;
using System.Collections.Generic;

namespace EventCloud.Application
{
    [AutoMapFrom(typeof(Creative))]
    public class CreativeListDto : FullAuditedEntityDto<int>, IOutputDto
    {
        public string Title { get; set; }

        public long UserId { get; set; }

        public int CategoryId { get; set; }
        //public CategoryListDto Category { get; set; }
        public string CategoryName { get; set; }
        public string CategoryUrl { get; set; }

        public IList<Tag> Tags { get; set; }
        public IList<Chapter> Chapters { get; set; }
        public double? CreativeRate { get; set; }
    }
}