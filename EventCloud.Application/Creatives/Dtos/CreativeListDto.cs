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

        public int CategoryId { get; set; }
        //public CategoryListDto Category { get; set; }
        public string CategoryName { get; set; }
        public string CategoryUrl { get; set; }

        public List<Tag> Tags { get; set; }
        public IList<Chapter> Capters { get; set; }
        public IList<Rate> Rates { get; set; }
    }
}