using Abp.Application.Services;
using EventCloud.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventCloud.Application
{
    public interface ICategoryAppService : IApplicationService
    {
        IEnumerable<CategoryListDto> GetList();
        Task<Category> Details(int id);
    }
}