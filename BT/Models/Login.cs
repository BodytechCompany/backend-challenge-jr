using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BT.Models
{
    public partial class Login
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Matricula")]
        [Required(ErrorMessage = "Informe a Matricula", AllowEmptyStrings = false)]
        public string Matricula_Usuario { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Tipo de Matricula")]
        public int TipoMatricula_id { get; set; }
        public TipoMatricula tipoMatricula { get; set; }
    }

}