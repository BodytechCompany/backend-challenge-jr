using Bodytech.Application.Common.Const;
using Bodytech.Application.Helper.Cypher;
using Bodytech.Application.Models.Auth;
using Bodytech.Application.Repository;
using Bodytech.Application.Repository.Roles;
using Bodytech.Application.Repository.Usuario;
using Bodytech.Application.Services.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bodytech.Application.Controllers
{
    /// <summary>
    /// Controller referente a autenticação
    /// </summary>
    public class AuthController : ApiController
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IJwtService jwtService;

        public AuthController(IUsuarioRepository usuarioRepository, IJwtService jwtService)
        {
            this.usuarioRepository = usuarioRepository;
            this.jwtService = jwtService;
        }

        [HttpPost]
        public HttpResponseMessage Token(AuthModel model)
        {
            var usuario = usuarioRepository.FindByUsernameAndPassword(model.Username, Cypher.Encrypt(model.Password));
            var token = jwtService.CreateToken(usuario.USUARIO_ID, usuario.DS_USERNAME, usuario.TB_USER_ROLES.Select(x => x.ROLE_ID));
            return Request.CreateResponse(HttpStatusCode.OK, new { Token = token });
        }
    }
}
