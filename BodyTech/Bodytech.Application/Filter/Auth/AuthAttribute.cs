using Bodytech.Application.Services.Jwt;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Bodytech.Application.Filter.Auth
{
    public class AuthAttribute : AuthorizationFilterAttribute
    {  
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            actionContext.Request.Headers.TryGetValues("Authorization", out var authHeader);
            if (authHeader == null || authHeader.Any(x => string.IsNullOrEmpty(x)))
            {
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.Unauthorized
                };

                var content = JsonConvert.SerializeObject(new { Message = "Você não possui autorização para fazer esta requisição." });
                actionContext.Response.Content = new StringContent(content);
                return;
            }

            base.OnAuthorization(actionContext);
        }
    }
}