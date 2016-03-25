using Abp.Application.Services;
using EventCloud.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventCloud.Tags
{
    public interface ITagAppService : IApplicationService
    {
        Task<Tag> Details(int id);
    }
}