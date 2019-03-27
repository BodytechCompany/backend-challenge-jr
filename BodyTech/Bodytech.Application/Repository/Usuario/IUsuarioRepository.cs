using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodytech.Application.Repository.Usuario
{
    public interface IUsuarioRepository : IRepository<TB_USUARIO>
    {
        IEnumerable<TB_USUARIO> FindAlunosByNameOrMatricula(string nome, string matricula);
        TB_USUARIO FindByUsernameAndPassword(string username, string password);

    }
}
