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
using EventCloud.Creatives;
using Newtonsoft.Json;

namespace EventCloud.Application
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

        public async Task<string> GetList(long id)
        {
            var creatives = await _creativeRepository
                .GetAll()
                .Where(c => c.UserId == id)
                .Include(c => c.Rates)
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            var mappedCreatives = new ListResultOutput<CreativeListDto>(creatives.MapTo<List<CreativeListDto>>());

            string jsonResult = JsonConvert.SerializeObject(mappedCreatives, Formatting.Indented,
                                   new JsonSerializerSettings
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });
            return jsonResult;
            //return new ListResultOutput<CreativeListDto>(creatives.MapTo<List<CreativeListDto>>());
        }

        public async Task Create(CreativeInput input)
        {
            var creative = new Creative
            {
                Title = input.Title,
                CreationTime = input.CreationTime,
                UserId = input.UserId,
                CategoryId = input.CategoryId
            };

            await _creativeRepository.InsertAsync(creative);
        }

        public async Task<string> Details(int id)
        {
            var creative = await _creativeRepository.GetAll()
                .Include(c => c.Category)
                .Include(c => c.Tags)
                .Include(c => c.Chapters)
                .Include(c => c.Rates)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (creative == null)
            {
                throw new UserFriendlyException("Could not found the creative.");
            }

            string jsonResult = JsonConvert.SerializeObject(creative, Formatting.Indented,
                                   new JsonSerializerSettings
                                   {
                                       ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                   });
            return jsonResult;
            //return creative.MapTo<CreativeListDto>();
        }

        public async Task Edit(CreativeEditInput input)
        {
            var creative = new Creative
            {
                Title = input.Title,
                CreationTime = input.CreationTime,
                UserId = input.UserId,
                CategoryId = input.CategoryId,
                Chapters = input.Chapters

            };

            await _creativeRepository.UpdateAsync(creative);
        }

        public async Task Delete(int creativeId)
        {
            await _creativeRepository.DeleteAsync(creativeId);
        }
    }
}