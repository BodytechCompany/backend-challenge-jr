using System.Web.Http;
using WebActivatorEx;
using Bodytech.Application;
using Swashbuckle.Application;
using Bodytech.Application.Filter.Operation;

namespace Bodytech.Application
{
    /// <summary>
    /// Classe de configuração de swagger
    /// </summary>
    public static class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Bodytech.Application");
                        c.IncludeXmlComments(GetXmlPath());
                        c.OperationFilter<AddAuthorizationHeaderFilter>();
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }

        private static string GetXmlPath()
        {
            return System.String.Format(@"{0}\bin\Bodytech.Application.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
