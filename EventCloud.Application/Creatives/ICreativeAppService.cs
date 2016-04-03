using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EventCloud.Creatives;
using System.Web.Http;
using System.Collections.Generic;

namespace EventCloud.Application
{
    public interface ICreativeAppService : IApplicationService
    {
        [HttpGet]
        IEnumerable<CreativeListDtoAll> GetAll();
        Task<IEnumerable<CreativeListDtoAll>> GetList(long userId);

        Task<string> Details(int creativeId);
        //Task<CreativeListDto> Details(int creativeId);

        Task Create(CreativeInput input);

        void Edit(CreativeEditInput input);

        Task Delete(int creativeId);

        void AddRate(RateInput input);
    }
}
