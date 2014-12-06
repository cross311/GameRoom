using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using GameRoom.GameService;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;

namespace GameRoom.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config, IGameRoomApplication application)
        {
            // dependancy injection
            var container = new UnityContainer();
            container.RegisterInstance(application);
            config.DependencyResolver = new UnityDependencyResolver(container);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //CORS
            var cors = new EnableCorsAttribute("http://localhost:8000", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
