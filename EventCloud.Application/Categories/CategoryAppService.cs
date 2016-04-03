using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Abp.Web.Models;
using EventCloud.Core.Entities;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;

namespace EventCloud.Application
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IRepository<Category, int> _categoryRepository;

        public CategoryAppService(
            IRepository<Category, int> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Details(int id)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(id);

            if (category == null)
            {
                throw new UserFriendlyException("Could not found the category.");
            }

            return category;
        }

        public IEnumerable<CategoryListDto> GetList()
        {
            return _categoryRepository.GetAll()
                .Select(c => new CategoryListDto { Id = c.Id, Name = c.Name, Url = c.Url})
                .ToList();
        }
    }
}