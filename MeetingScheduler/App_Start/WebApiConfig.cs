using MeetingScheduler.Contract;
using MeetingScheduler.Implementation;
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

            var container = new Container(x => { x.For<IRegistration>().Use<Registration>(); });
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
