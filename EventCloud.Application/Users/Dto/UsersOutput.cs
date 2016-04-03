using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCloud.Users
{
    public class UsersOutput : IOutputDto
    {
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public IEnumerable<string> Medals { get; set; }
    }
}
