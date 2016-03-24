using Abp.Application.Services.Dto;
using EventCloud.Core.Entities;
using System;
using System.Collections.Generic;

namespace EventCloud.Creatives
{
    public class CreativeInput : IInputDto
    {
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public DateTime CreationTime { get; set; }
        public IList<Chapter> Capters { get; set; }
        public IList<Rate> Rates { get; set; }
    }
}