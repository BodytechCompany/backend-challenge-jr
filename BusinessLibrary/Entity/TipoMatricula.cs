using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessLibrary.Entity
{
    public partial class TipoMatricula
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoMatricula_id { get; set; }

        [Required(ErrorMessage = "Informe o Tipo de matricula", AllowEmptyStrings = false)]
        public string Descricao { get; set; }
 

         }

}