using Abp.Application.Services;
using EventCloud.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace EventCloud.Application
{
    public interface ICategoryAppService : IApplicationService
    {
        [HttpGet]
        IEnumerable<CategoryListDto> GetList();
        [ResponseType(typeof(Category))]
        Task<Category> GetCategory(int id);
        Task PutCategory(Category category);
        [HttpPost]
        void Create([FromBody]Category category);
        [HttpDelete]
        Task Delete([FromBody]int categoryId);
    }
}