using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;
using EventCloud.Application;
using Abp.Web;

namespace EventCloud.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(EventCloudApplicationModule))]
    public class EventCloudWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(EventCloudApplicationModule).Assembly, "app")
                .Build();

            DynamicApiControllerBuilder
                .For<ICreativeAppService>("app/creative")
                .ForMethod("GetAll").WithVerb(HttpVerb.Get)
                .Build();

            DynamicApiControllerBuilder
                .For<ICategoryAppService>("app/category")
                .ForMethod("Create").WithVerb(HttpVerb.Post)
                .ForMethod("Delete").WithVerb(HttpVerb.Delete)
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
        }
    }
}
