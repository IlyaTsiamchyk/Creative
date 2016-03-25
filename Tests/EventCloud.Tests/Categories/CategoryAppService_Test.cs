using EventCloud.Categories;
using EventCloud.Core.Entities;
using EventCloud.Tests.Sessions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EventCloud.Tests.Categories
{
    public class CategoryAppService_Test : EventCloudTestBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryAppService_Test()
        {
            _categoryAppService = Resolve<ICategoryAppService>();
        }

        [Fact]
        public async Task Should_Get_Creative_List_By_Category()
        {
            Category category = await _categoryAppService.Details(1);

            category.ShouldNotBe(null);

        }
    }
}
