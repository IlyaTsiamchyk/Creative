using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EventCloud.Core.Entities;
using EventCloud.Creatives;
using System;
using System.Collections.Generic;

namespace EventCloud.Application
{
    public class CreativeListDtoAll : FullAuditedEntityDto<int>, IOutputDto
    {
        public string Title { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }
        //public CategoryListDto Category { get; set; }
        public string CategoryName { get; set; }
        public string CategoryUrl { get; set; }
        public double? CreativeRate { get; set; }
    }
}