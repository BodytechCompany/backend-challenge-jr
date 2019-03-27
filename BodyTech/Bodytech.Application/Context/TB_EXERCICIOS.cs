using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bodytech.Application.Repository
{
    /// <summary>
    /// Tabela de Exercicio, dados referente aos exercicios do aluno
    /// </summary>
    public class TB_EXERCICIOS
    {
        [Key]
        public int EXERCICIO_ID { get; set; }
        public int NUM_ORDEM { get; set; }
        public string DS_EXERCICIO { get; set; }
        public string DS_REPETICAO { get; set; }
        public double NUM_CARGA { get; set; }
        [ForeignKey("FK_ALUNO")]
        public int FK_ALUNO_ID { get; set; }
        public TB_USUARIO FK_ALUNO { get; set; }
        [ForeignKey("FK_PROFESSOR")]
        public int FK_PROFESSOR_ID { get; set; }
        public TB_USUARIO FK_PROFESSOR { get; set; }
        public DateTime? DT_DATA_TREINO { get; set; }
    }
}