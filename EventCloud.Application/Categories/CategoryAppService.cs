using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Abp.Web.Models;
using EventCloud.Core.Entities;
using System.Threading.Tasks;

namespace EventCloud.Categories
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
    }
}