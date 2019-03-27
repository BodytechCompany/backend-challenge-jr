using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bodytech.Application.Repository
{
    /// <summary>
    /// Tabela de Roles, onde informa se o usuario é aluno ou professor
    /// </summary>
    public class TB_ROLES
    {
        [Key]
        public int ROLE_ID { get; set; }
        public string DS_ROLE { get; set; }
    }
}