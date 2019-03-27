using Bodytech.Application.Filter.Auth;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace Bodytech.Application.Filter.Operation
{
    public class AddAuthorizationHeaderFilter : IOperationFilter
    {
        public void Apply(Swashbuckle.Swagger.Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation == null) return;

            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }

            var parameter = new Parameter
            {
                description = "The authorization token",
                @in = "header",
                name = "Authorization",
                required = true,
                type = "string"
            };

            if (apiDescription.GetControllerAndActionAttributes<AuthAttribute>().Any())
            {
                operation.parameters.Add(parameter);
            }
        }
    }
}