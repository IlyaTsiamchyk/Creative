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
using EventCloud.Contracts;
using EventCloud.Core.Entities;

namespace EventCloud.Application
{
    [AbpAuthorize]
    public class CreativeAppService : EventCloudAppServiceBase, ICreativeAppService
    {
        private readonly ICreativeRepository _creativeRepository;

        public CreativeAppService(
            ICreativeRepository creativeRepository)
        {
            _creativeRepository = creativeRepository;
        }

        public IEnumerable<CreativeListDtoAll> GetAll()
        {
            var creatives = _creativeRepository
                .GetAll()
                .Include(c => c.Rates)
                .OrderByDescending(e => e.CreationTime)
                .Select(c => new CreativeListDtoAll
                {
                    Id = c.Id,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name,
                    CategoryUrl = c.Category.Url,
                    CreativeRate = c.Rates.Average(x => x.Value),
                    CreationTime = c.CreationTime,
                    Title = c.Title,
                    UserId = c.UserId
                })
                .ToList();

            var fts = _creativeRepository.FullTextSearch("The");
            var res = fts.ToList();
            var sec = _creativeRepository.FullTextSearch("the").ToList();

            return creatives;
        }
        public async Task<IEnumerable<CreativeListDtoAll>> GetList(long id)
        {
            var creatives = await _creativeRepository
                .GetAll()
                .Where(c => c.UserId == id)
                .OrderByDescending(e => e.CreationTime)
                .Select(c => new CreativeListDtoAll
                {
                    Id = c.Id,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name,
                    CategoryUrl = c.Category.Url,
                    CreativeRate = c.Rates.Average(x => x.Value),
                    CreationTime = c.CreationTime,
                    Title = c.Title,
                    UserId = c.UserId
                })
                .ToListAsync();

            return creatives;

            //var mappedCreatives = new ListResultOutput<CreativeListDto>(creatives.MapTo<List<CreativeListDto>>());

            //string jsonResult = JsonConvert.SerializeObject(mappedCreatives, Formatting.None,
            //                       new JsonSerializerSettings
            //                    {
            //                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //                    });
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
                .Select(c => new CreativeListDto {
                    Capters = c.Chapters, Tags = c.Tags,
                    Id = c.Id, CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name,
                    CategoryUrl = c.Category.Url,
                    CreativeRate = c.Rates.Average(x => x.Value),
                    CreationTime = c.CreationTime, Title = c.Title,
                    UserId = c.UserId
                })
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

        public void Edit(CreativeEditInput input)
        {
            var creative = new Creative
            {
                Id = input.Id,
                Title = input.Title,
                CreationTime = input.CreationTime,
                UserId = input.UserId,
                CategoryId = input.CategoryId
            };

            _creativeRepository.Update(creative);

            foreach (var chapter in input.Chapters)
            {
                //chapter.Creative = creative;
                _creativeRepository.UpdateChapter(chapter);
            }

            foreach (var tag in input.Tags)
            {
                _creativeRepository.UpdateTag(tag);
            }
        }

        public async Task Delete(int creativeId)
        {
            await _creativeRepository.DeleteAsync(creativeId);
        }

        public void AddRate(RateInput input)
        {
            try
            {
                _creativeRepository.AddRate(new Rate { UserBy = input.UserBy, CreativeId = input.CreativeId, Value = input.Value });
            }
            catch (ArgumentException ex)
            {
            }
        }

        public List<Tag> GetTags()
        {
            return _creativeRepository.GetTags();
        }
    }
}