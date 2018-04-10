using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessLibrary.Entity
{
    public class Exercicio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Exer_id { get; set; }
        [DisplayName("Ordem")]
        public int exer_nr_ordem { get; set; }

        // Foreign Key
        public int clie_id { get; set; }
        [DisplayName("Exercicio"), Required]
        public string exer_nm_nome { get; set; }
        [DisplayName("Repeticao")]
        public string exer_nm_repeticao { get; set; }
        [DisplayName("Carga")]
        public int exer_db_carga { get; set; }
        // Foreign Key
        public int prof_id { get; set; }
        // Navigation property
        public Professor professor { get; set; }
        public Cliente Cliente { get; set; }

    }
}