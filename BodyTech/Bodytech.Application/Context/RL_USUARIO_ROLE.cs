using Bodytech.Application.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bodytech.Application.Context
{
    /// <summary>
    /// Tabela que relaciona o usuario com o roles
    /// </summary>
    public class RL_USUARIO_ROLE
    {
        [Key]
        public int RL_USUARIO_ROLE_ID { get; set; }
        [ForeignKey("TB_USUARIO")]
        public int FK_USUARIO_ID { get; set; }
        public TB_USUARIO TB_USUARIO { get; set; }
        [ForeignKey("TB_ROLES")]
        public int FK_ROLE_ID { get; set; }
        public TB_ROLES TB_ROLES { get; set; }
    }
}