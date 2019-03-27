using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Bodytech.Application.Common.Const;
using Bodytech.Application.Common.Exception;

namespace Bodytech.Application.Repository.Excercicio
{
    public class ExercicioRepository : IExercicioRepository
    {
        private readonly BodyTechContext Context;

        public ExercicioRepository(BodyTechContext context)
        {
            Context = context;
        }

        public TB_EXERCICIOS Add(TB_EXERCICIOS entity)
        {
            var existemOrdem = Context.TB_EXERCICIOS.Any(x => x.FK_ALUNO_ID == entity.FK_ALUNO_ID && x.NUM_ORDEM == entity.NUM_ORDEM);
            if (existemOrdem)
                throw new Exception(Messages.OrdemJaCadastrada);

            var exercicio = Context.TB_EXERCICIOS.Add(entity);
            Context.SaveChanges();
            return exercicio;
        }

        public void Delete(int Id)
        {
            var exercicio = Context.TB_EXERCICIOS.SingleOrDefault(x => x.EXERCICIO_ID == Id);
            if (exercicio == null)
                throw new Exception(ExceptionMessages.ExercicioNaoEncontrado);

            var idAluno = exercicio.FK_ALUNO_ID;
            var exercicios = Context.TB_EXERCICIOS.Where(x => x.FK_ALUNO_ID == idAluno && x.EXERCICIO_ID != Id).OrderBy(x => x.NUM_ORDEM);

            int novaOrdem = 1;
            foreach (var exer in exercicios)
            {
                exer.NUM_ORDEM = novaOrdem;
                novaOrdem++;
            }

            this.Context.TB_EXERCICIOS.Remove(exercicio);
            Context.SaveChanges();
        }

        public TB_EXERCICIOS Find(int Id)
        {
            var exercicio = Context.TB_EXERCICIOS.SingleOrDefault(x => x.EXERCICIO_ID == Id);
            if (exercicio == null)
                throw new Exception(ExceptionMessages.ExercicioNaoEncontrado);

            return exercicio;
        }

        public IEnumerable<TB_EXERCICIOS> Get()
        {
            return Context.TB_EXERCICIOS.ToList();
        }

        public TB_EXERCICIOS Update(TB_EXERCICIOS entity)
        {
            var exercicio = Context.TB_EXERCICIOS.SingleOrDefault(x => x.EXERCICIO_ID == entity.EXERCICIO_ID);
            if (exercicio == null)
                throw new Exception(ExceptionMessages.ExercicioParaUsuarioNaoEncontrado);

            var existeExercicioComOrdem = Context.TB_EXERCICIOS.FirstOrDefault(x => x.FK_ALUNO_ID == entity.FK_ALUNO_ID && x.NUM_ORDEM == entity.NUM_ORDEM);
            if (existeExercicioComOrdem != null)
                existeExercicioComOrdem.NUM_ORDEM = exercicio.NUM_ORDEM;

            exercicio.NUM_ORDEM = entity.NUM_ORDEM;
            exercicio.DS_EXERCICIO = entity.DS_EXERCICIO;
            exercicio.DS_REPETICAO = entity.DS_REPETICAO;
            exercicio.NUM_CARGA = entity.NUM_CARGA;
            exercicio.DT_DATA_TREINO = entity.DT_DATA_TREINO;

            Context.SaveChanges();
            return exercicio;
        }

        public IEnumerable<TB_EXERCICIOS> FindExercicioByAlunoId(int id)
        {
            var exercicio = Context.TB_EXERCICIOS
                .Where(x => x.FK_ALUNO_ID.Equals(id))
                .ToList();

            return exercicio;
        }

        public IEnumerable<TB_EXERCICIOS> AddMany(IEnumerable<TB_EXERCICIOS> entity)
        {
            if (entity == null || !entity.Any())
                return entity;

            var ordem = entity.Select(x => x.NUM_ORDEM).ToArray();
            var agruparOrdem = ordem.GroupBy(x => x);
            if (agruparOrdem.Any(x => x.Count() > 1))
                throw new Exception(ExceptionMessages.OrdemRepetida);

            var idAluno = entity.First().FK_ALUNO_ID;
            var existeOrdem = Context.TB_EXERCICIOS.Any(x => x.FK_ALUNO_ID == idAluno && ordem.Contains(x.NUM_ORDEM));

            if (existeOrdem)
                throw new Exception(Messages.OrdemJaCadastrada);

            entity = Context.TB_EXERCICIOS.AddRange(entity);
            Context.SaveChanges();

            return entity;
        }

        public TB_EXERCICIOS AtualizarCarga(int id, double carga)
        {
            var exercicio = Context.TB_EXERCICIOS.SingleOrDefault(x => x.EXERCICIO_ID == id);
            if (exercicio == null)
                throw new Exception(ExceptionMessages.ExercicioNaoEncontrado);

            exercicio.NUM_CARGA = carga;
            Context.SaveChanges();

            return exercicio;
        }
    }

}