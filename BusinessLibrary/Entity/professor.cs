using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessLibrary.Entity
{
    public class Professor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Nome do Professor"), Required]
        public int prof_id { get; set; }
        [DisplayName("Nome do Professor"), Required]
        public string prof_nm_nome { get; set; }
    }
}