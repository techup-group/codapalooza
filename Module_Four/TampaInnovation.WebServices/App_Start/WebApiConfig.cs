using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TampaInnovation.WebServices
{
    public static class WebApiConfig
    {
        private static void ConfigureApi(HttpConfiguration config)
        {
            int index = config.Formatters.IndexOf(config.Formatters.JsonFormatter);
            config.Formatters[index] = new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver(), DefaultValueHandling = DefaultValueHandling.Ignore}
            };
        }

        public static void Register(HttpConfiguration config)
        {
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            ConfigureApi(config);
        }
    }
}