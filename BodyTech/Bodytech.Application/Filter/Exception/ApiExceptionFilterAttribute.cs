using Bodytech.Application.Common.Exception;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Bodytech.Application.Filter.Exception
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var response = new HttpResponseMessage();
            var ex = actionExecutedContext.Exception;
            if (ex is SegurancaException)
                response.StatusCode = HttpStatusCode.Unauthorized;
            else
                response.StatusCode = HttpStatusCode.BadRequest;

            var problemDetails = new ProblemDetails
            {
                Type = actionExecutedContext.Request.RequestUri.AbsoluteUri,
                Title = ex.Message,
                Detail = ex.InnerException?.Message,
                Instance = actionExecutedContext.Request.RequestUri.AbsolutePath,
            };

            response.Content = new StringContent(JsonConvert.SerializeObject(problemDetails));
            actionExecutedContext.Response = response;

            base.OnException(actionExecutedContext);
        }
    }
}