using Bodytech.Application.Common.Const;
using Bodytech.Application.Filter.Auth;
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
    /// Controller Aluno 
    /// </summary>
    [Auth]
    public class AlunoController : BaseController
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IJwtService jwtService;

        public AlunoController(IUsuarioRepository usuarioRepository, IJwtService jwtService)
        {
            this.usuarioRepository = usuarioRepository;
            this.jwtService = jwtService;
        }

        public HttpResponseMessage Get(string nome, string matricula)
        {
            var token = GetAuthToken();
            var tokenModel = jwtService.ReadToken(token);
            if (tokenModel.Roles.Any(x => x.Equals((int)Roles.PROFESSOR)))
            {
                var alunos = usuarioRepository.FindAlunosByNameOrMatricula(nome, matricula);
                return Request.CreateResponse(HttpStatusCode.OK, alunos);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { ErrorMessage = ExceptionMessages.PesquisarAluno });
            }
        }
    }
}
