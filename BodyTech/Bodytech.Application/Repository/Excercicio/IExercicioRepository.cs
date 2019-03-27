using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodytech.Application.Repository.Excercicio
{
    public interface IExercicioRepository : IRepository<TB_EXERCICIOS>
    {
        IEnumerable<TB_EXERCICIOS> FindExercicioByAlunoId(int id);
        IEnumerable<TB_EXERCICIOS> AddMany(IEnumerable<TB_EXERCICIOS> entity);
        TB_EXERCICIOS AtualizarCarga(int id, double carga);

    }
}