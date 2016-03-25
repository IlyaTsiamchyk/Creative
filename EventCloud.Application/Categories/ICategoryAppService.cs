using Abp.Application.Services;
using EventCloud.Core.Entities;
using System.Threading.Tasks;

namespace EventCloud.Categories
{
    public interface ICategoryAppService : IApplicationService
    {
        Task<Category> Details(int id);
    }
}