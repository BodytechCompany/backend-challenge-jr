using Bodytech.Application.Common.Const;
using Bodytech.Application.Filter.Auth;
using Bodytech.Application.Models.Exercicio;
using Bodytech.Application.Repository;
using Bodytech.Application.Repository.Excercicio;
using Bodytech.Application.Services.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bodytech.Application.Controllers
{
    [Auth]
    public class ExercicioController : BaseController
    {
        private readonly IExercicioRepository exercicioRepository;
        private readonly IJwtService jwtService;

        public ExercicioController(IExercicioRepository exercicioRepository, IJwtService jwtService)
        {
            this.exercicioRepository = exercicioRepository;
            this.jwtService = jwtService;
        }

        public HttpResponseMessage Get(int idAluno)
        {
            var token = GetAuthToken();
            var tokenModel = jwtService.ReadToken(token);
            var exercicio = exercicioRepository.FindExercicioByAlunoId(idAluno);

            if (tokenModel.Roles.Any(x => x.Equals((int)Roles.PROFESSOR)))
                return Request.CreateResponse(HttpStatusCode.OK, exercicio);
            else
            {
                if (idAluno.ToString() != tokenModel.UserId)
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, new { ErrorMessage = ExceptionMessages.PermissaoConsultarExercicioOutroAluno });

                return Request.CreateResponse(HttpStatusCode.OK, exercicio);
            }
        }

        /// <summary>
        ///  Incluir um novo exercicio para o aluno passando o identificador do seu professor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post(IEnumerable<IncluirExercicioModel> model)
        {
            var token = GetAuthToken();
            var tokenModel = jwtService.ReadToken(token);
            if (tokenModel.Roles.Contains((int)Roles.PROFESSOR))
            {
                var entity = model.Select(x => new TB_EXERCICIOS
                {
                    DS_EXERCICIO = x.Descricao,
                    DS_REPETICAO = x.DescricaoRepeticao,
                    FK_ALUNO_ID = x.IdAluno,
                    FK_PROFESSOR_ID = x.IdProfessor,
                    NUM_CARGA = x.Carga,
                    NUM_ORDEM = x.Ordem
                });

                entity = exercicioRepository.AddMany(entity);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                throw new Exception(ExceptionMessages.PermissaoCadastrarExercicio);
            }
        }

        /// <summary>
        /// Atualizar exercicio de acordo com o tipo de usuario (Aluno ou Professor)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Put(AtualizaExercicioModel model)
        {
            var token = GetAuthToken();
            var tokenModel = jwtService.ReadToken(token);
            if (tokenModel.Roles.Contains((int)Roles.PROFESSOR))
            {
                var entity = new TB_EXERCICIOS
                {
                    EXERCICIO_ID = model.IdExercicio,
                    DS_EXERCICIO = model.Descricao,
                    DS_REPETICAO = model.DescricaoRepeticao,
                    FK_ALUNO_ID = model.IdAluno,
                    FK_PROFESSOR_ID = model.IdProfessor,
                    NUM_CARGA = model.Carga,
                    NUM_ORDEM = model.Ordem
                };

                entity = exercicioRepository.Update(entity);
            }
            else
            {
                if (model.Carga <= 0)
                    throw new Exception(ExceptionMessages.CargaValor);

                exercicioRepository.AtualizarCarga(model.IdExercicio, model.Carga);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            var token = GetAuthToken();
            var tokenModel = jwtService.ReadToken(token);
            if (tokenModel.Roles.Contains((int)Roles.PROFESSOR))
            {
                exercicioRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, Messages.OperacaoSucesso);
            }
            else
                throw new Exception(ExceptionMessages.PermissaoDeletarExercicio);
        }
    }
}
