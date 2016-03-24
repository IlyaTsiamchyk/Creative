using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EventCloud.Events.Dtos;

namespace EventCloud.Creatives
{
    public interface ICreativeAppService : IApplicationService
    {
        Task<ListResultOutput<CreativeListDto>> GetList(GetCreativeListInput input);

        Task<Creative> Get(int id);

        Task Create(CreateCreativeInput input);

        //Task Cancel(EntityRequestInput<Guid> input);

        //Task<EventRegisterOutput> Register(EntityRequestInput<Guid> input);

        //Task CancelRegistration(EntityRequestInput<Guid> input);
    }
}
