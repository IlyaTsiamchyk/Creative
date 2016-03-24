using System.Threading.Tasks;
using EventCloud.Sessions;
using Shouldly;
using Xunit;
using EventCloud.Creatives;
using EventCloud.EntityFramework;
using System.Linq;
using System;
using EventCloud.Tests.Sessions;

namespace EventCloud.Tests.Creatives
{
    public class CreativeAppService_Tests : EventCloudTestBase
    {
        private readonly ICreativeAppService _creativeAppService;

        public CreativeAppService_Tests()
        {
            _creativeAppService = Resolve<ICreativeAppService>();
        }

        [Fact]
        public async Task Should_Get_Creative_When_Use_GetList()
        {
            //Arrange
            LoginAsHostAdmin();

            //Act
            var output = await _creativeAppService.GetList(new GetCreativeListInput());

            //Assert
            output.Items.Count.ShouldBe(5);
            output.Items[0].Tags.Count.ShouldBe(3);
        }

        private static Creative GetTestEvent(EventCloudDbContext context)
        {
            return context.Creatives.Single(e => e.Id == 1);
        }
    }
}
