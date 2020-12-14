using DevFramework.Northwind.WebApi.MessageHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DevFramework.Northwind.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //yapılan her isteğin önünde yazılan token serviz çalışıcak demektir.
            config.MessageHandlers.Add(new AuthenticationHandler());

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
