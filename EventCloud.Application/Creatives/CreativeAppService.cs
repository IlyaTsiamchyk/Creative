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

        public async Task<ListResultOutput<CreativeListDto>> GetList(long id)
        {
            var creatives = await _creativeRepository
                .GetAll()
                .Where(c => c.UserId == id)
                .Include(c => c.Category)
                .Include(c => c.Tags)
                .Include(c => c.Capters)
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            return new ListResultOutput<CreativeListDto>(creatives.MapTo<List<CreativeListDto>>());
        }

        public async Task Create(CreativeInput input)
        {
            var creative = new Creative { Title = input.Title, CreationTime = input.CreationTime
                            , UserId = input.UserId, CategoryId = input.CategoryId };

            await _creativeRepository.InsertAsync(creative);
        }

        public Task<Creative> Details(int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(CreativeInput input)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int creativeId)
        {
            throw new NotImplementedException();
        }
    }
}