using MeetingScheduler.Authentication;
using MeetingScheduler.Contract;
using MeetingScheduler.Filter;
using MeetingScheduler.Implementation;
using MeetingScheduler.Persistence.Contract;
using MeetingScheduler.SQL;
using MeetingScheduler.StructureMap;
using StructureMap;
using System.Web.Http;

namespace MeetingScheduler  
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //1. Setting up StructureMap and DependencyResolver
            var registry = new Registry();
            registry.IncludeRegistry<DependencyRegistry>();
            var container = new Container(registry);
            GlobalConfiguration.Configuration.DependencyResolver = new DependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
