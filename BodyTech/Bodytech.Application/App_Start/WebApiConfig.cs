using Bodytech.Application.Filter.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Bodytech.Application
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            //formatters
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //filters
            config.Filters.Add(new ApiExceptionFilterAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            SwaggerConfig.Register();
        }
    }
}
