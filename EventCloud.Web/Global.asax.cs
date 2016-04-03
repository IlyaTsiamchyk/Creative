using System;
using Abp.Dependency;
using Abp.Web;
using Castle.Facilities.Logging;
using System.Web.Http;

namespace EventCloud.Web
{
    public class MvcApplication : AbpWebApplication
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            base.Application_Start(sender, e);
        }
    }
}
