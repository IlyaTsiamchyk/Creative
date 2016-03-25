using EventCloud.Categories;
using EventCloud.Core.Entities;
using EventCloud.Tags;
using EventCloud.Tests.Sessions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EventCloud.Tests.Tags
{
    public class TagAppService_Test : EventCloudTestBase
    {
        private readonly ITagAppService _tagAppService;

        public TagAppService_Test()
        {
            _tagAppService = Resolve<ITagAppService>();
        }

        [Fact]
        public async Task Should_Get_Creative_List_By_Category()
        {
            Tag tag = await _tagAppService.Details(1);

            tag.ShouldNotBe(null);

        }
    }
}
