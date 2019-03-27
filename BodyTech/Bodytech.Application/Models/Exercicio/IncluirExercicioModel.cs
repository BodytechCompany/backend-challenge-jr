using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodytech.Application.Models.Exercicio
{
    public class IncluirExercicioModel
    {
        public int Ordem { get; set; }
        public string Descricao { get; set; }
        public string DescricaoRepeticao { get; set; }
        public double Carga { get; set; }
        public int IdAluno { get; set; }
        public int IdProfessor { get; set; }
    }
}