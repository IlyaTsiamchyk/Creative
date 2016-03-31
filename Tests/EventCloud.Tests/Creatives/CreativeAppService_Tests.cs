using System.Threading.Tasks;
using EventCloud.Sessions;
using Shouldly;
using Xunit;
using EventCloud.Creatives;
using EventCloud.EntityFramework;
using System.Linq;
using System;
using EventCloud.Tests.Sessions;
using Abp.Timing;
using EventCloud.Application;

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
        public async Task Should_Get_Creatives_When_Use_GetList()
        {
            //Act
            var output = await _creativeAppService.GetList(1);

            ////Assert
            //output.Items.Count.ShouldBe(5);
            //output.Items[0].Tags.Count.ShouldBe(3);
            //output.Items[0].UserId.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Create_Creative()
        {
            var title = Guid.NewGuid().ToString();

            //Act
            await _creativeAppService.Create(new CreativeInput { CreationTime = Clock.Now, Title = title, CategoryId = 1, UserId = 1});

            UsingDbContext(context =>
            {
                context.Creatives.FirstOrDefault(c => c.Title == title).ShouldNotBe(null);
            });
        }

        //[Fact]
        //public async Task Should_Get_Creative_Detail()
        //{
        //    Creative creative = null;
        //    //Act
        //    await UsingDbContext(async context =>
        //    {
        //        creative = await _creativeAppService.Details(1);

        //        creative.Category.ShouldNotBe(null);
        //        creative.ShouldNotBe(null);
        //    });

        //}

        [Fact]
        public async Task Should_Delete_Creative()
        {
            await _creativeAppService.Delete(1);

            UsingDbContext(context =>
            {
                context.Creatives.FirstOrDefault(c => c.Id == 1).ShouldBe(null);
            });
        }

        private static Creative GetTestEvent(EventCloudDbContext context)
        {
            return context.Creatives.Single(e => e.Id == 1);
        }
    }
}
