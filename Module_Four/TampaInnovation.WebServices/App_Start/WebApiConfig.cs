using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TampaInnovation.WebServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                    name: "DefaultApiByName",
                    routeTemplate: "api/{controller}/{action}/{name}",
                     defaults: new { id = RouteParameter.Optional }
                    );

            config.Routes.MapHttpRoute(
                name: "DefaultApiByAction",
                routeTemplate: "api/{controller}/{action}"
                );

        }
    }
}
    
    

