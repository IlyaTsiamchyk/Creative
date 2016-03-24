using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EventCloud.Events.Dtos;

namespace EventCloud.Creatives
{
    public interface ICreativeAppService : IApplicationService
    {
        Task<ListResultOutput<CreativeListDto>> GetList(long userId);

        Task<Creative> Details(int creativeId);

        Task Create(CreativeInput input);

        Task Edit(CreativeInput input);

        Task Delete(int creativeId);
    }
}
