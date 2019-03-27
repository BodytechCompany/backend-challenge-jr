using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bodytech.Application.Repository
{
    /// <summary>
    /// Tabela de Usuario, dados referente ao aluno e o professor
    /// </summary>
    public class TB_USUARIO
    {
        [Key]
        public int USUARIO_ID { get; set; }
        public string DS_USERNAME { get; set; }
        public string DS_PASSWORD { get; set; }
        public string DS_NOME { get; set; }
        public string MATRICULA { get; set; }
        /// <summary>
        /// Referencia a tabela de Roles, onde verifica que tipo de usuario é (Aluno ou Professor)
        /// </summary>
        public IEnumerable<TB_ROLES> TB_USER_ROLES { get; set; }
    }
}