﻿using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EventCloud.Creatives;
using System.Web.Http;
using System.Collections.Generic;
using EventCloud.Core.Entities;

namespace EventCloud.Application
{
    public interface ICreativeAppService : IApplicationService
    {
        [HttpGet]
        IEnumerable<CreativeListDtoAll> GetAll();
        Task<IEnumerable<CreativeListDtoAll>> GetList(long userId);
        List<Tag> GetTags();

        Task<string> Details(int creativeId);
        //Task<CreativeListDto> Details(int creativeId);

        Task Create(CreativeInput input);

        void Edit(CreativeEditInput input);

        Task Delete(int id);

        void AddRate(RateInput input);
    }
}
