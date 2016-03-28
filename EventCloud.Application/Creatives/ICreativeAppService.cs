using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EventCloud.Creatives;

namespace EventCloud.Application
{
    public interface ICreativeAppService : IApplicationService
    {
        Task<string> GetList(long userId);

        Task<string> Details(int creativeId);
        //Task<CreativeListDto> Details(int creativeId);

        Task Create(CreativeInput input);

        Task Edit(CreativeEditInput input);

        Task Delete(int creativeId);
    }
}
