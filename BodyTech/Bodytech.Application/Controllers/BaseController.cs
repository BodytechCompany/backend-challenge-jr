using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bodytech.Application.Controllers
{
    /// <summary>
    /// Controller base com metodos comuns entre as outras api's
    /// </summary>
    public class BaseController : ApiController
    {
        /// <summary>
        /// Metodo para obter o token no Authorization header
        /// </summary>
        /// <returns></returns>
        protected string GetAuthToken()
        {
            Request.Headers.TryGetValues("Authorization", out var authHeader);
            var token = authHeader.FirstOrDefault();
            return token;
        }
    }
}
