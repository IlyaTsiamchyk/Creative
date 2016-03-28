using Abp.Application.Services.Dto;
using EventCloud.Creatives;
using System.Collections.Generic;

namespace EventCloud.Application
{
    public class CategoryListDto : IOutputDto
    {
        public virtual string Name { get; set; }
        public virtual IList<Creative> Creatives { get; set; }
        public virtual string Url { get; set; }
    }
}