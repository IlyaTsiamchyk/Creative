using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EventCloud.Core.Entities;
using EventCloud.Creatives;
using System.Collections.Generic;

namespace EventCloud.Application
{
    [AutoMapFrom(typeof(Category))]
    public class CategoryListDto : IOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}