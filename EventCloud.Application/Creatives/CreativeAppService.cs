using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using EventCloud.Events.Dtos;
using EventCloud.Users;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.UI;
using Abp.Application.Services.Dto;

namespace EventCloud.Creatives
{
    [AbpAuthorize]
    public class CreativeAppService : EventCloudAppServiceBase, ICreativeAppService
    {
        private readonly IRepository<Creative, int> _creativeRepository;

        public CreativeAppService(
            IRepository<Creative, int> creativeRepository)
        {
            _creativeRepository = creativeRepository;
        }

        public async Task<ListResultOutput<CreativeListDto>> GetList(GetCreativeListInput input)
        {
            var creatives = await _creativeRepository
                .GetAll()
                .Include(c => c.Category.Name)
                .Include(c => c.Tags)
                .Include(c => c.Capters)
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            return new ListResultOutput<CreativeListDto>(creatives.MapTo<List<CreativeListDto>>());
        }

        public async Task Create(CreateCreativeInput input)
        {
            var creative = new Creative { Title = input.Title, CreationTime = input.CreationTime
                            , };

            await _creativeRepository.InsertAsync(creative);
        }

        public Task<Creative> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}