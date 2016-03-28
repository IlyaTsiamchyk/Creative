using Abp.Application.Services.Dto;
using EventCloud.Core.Entities;
using System;
using System.Collections.Generic;

namespace EventCloud.Application
{
    public class CreativeEditInput : IInputDto
    {
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public DateTime CreationTime { get; set; }
        public IList<Chapter> Chapters { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}