using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodytech.Application.Common.Const
{
    public class ExceptionMessages
    {
        public const string OrdemRepetida = "Número de ordem não pode se repetir.";
        public const string CargaValor = "O valor da carga deve ser maior do 0.";
        public const string PermissaoCadastrarExercicio = "Você não tem permissão para cadastrar exercicio.";
        public const string PermissaoDeletarExercicio = "Somente um professor pode apagar o exercicio.";
        public const string PermissaoConsultarExercicioOutroAluno = "Você não pode ver os exercicios de outros alunos.";
        public const string ExercicioNaoEncontrado = "Exercício não encontrado.";
        public const string ExercicioParaUsuarioNaoEncontrado = "Exercício para este usuário não encontrado.";
        public const string UsuarioNaoEncontrado = "Usuario não encontrado.";
        public const string PesquisarAluno = "Somente professores tem permissão de pesquisa de alunos.";
        public const string RoleNaoCadastrada = "Role não cadastrada.";
        public const string TokenInvalido = "Token inválido.";
    }
}