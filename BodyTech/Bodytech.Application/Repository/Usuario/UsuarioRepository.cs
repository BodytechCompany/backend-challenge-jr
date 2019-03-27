using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Bodytech.Application.Common.Const;
using Bodytech.Application.Common.Exception;

namespace Bodytech.Application.Repository.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BodyTechContext Context;

        public UsuarioRepository(BodyTechContext context)
        {
            Context = context;
        }

        public TB_USUARIO Add(TB_USUARIO entity)
        {
            entity = Context.TB_USUARIOS.Add(entity);
            Context.SaveChanges();

            entity.MATRICULA = entity.USUARIO_ID.ToString().PadLeft(8, '0');
            Context.SaveChanges();

            return entity;
        }

        public void Delete(int Id)
        {
            var usuario = Context.TB_USUARIOS.SingleOrDefault(x => x.USUARIO_ID == Id);
            if (usuario == null)
                throw new Exception(ExceptionMessages.UsuarioNaoEncontrado);

            this.Context.TB_USUARIOS.Remove(usuario);
            Context.SaveChanges();
        }

        public TB_USUARIO Find(int Id)
        {
            var usuario = Context.TB_USUARIOS.SingleOrDefault(x => x.USUARIO_ID == Id);
            if (usuario == null)
                throw new Exception(ExceptionMessages.UsuarioNaoEncontrado);

            return usuario;
        }



        public IEnumerable<TB_USUARIO> Get()
        {
            return Context.TB_USUARIOS.ToList();
        }

        public TB_USUARIO Update(TB_USUARIO entity)
        {
            var usuario = Context.TB_USUARIOS.SingleOrDefault(x => x.USUARIO_ID == entity.USUARIO_ID);
            if (usuario == null)
                throw new Exception(ExceptionMessages.UsuarioNaoEncontrado);

            usuario.DS_NOME = entity.DS_NOME;
            usuario.DS_USERNAME = entity.DS_USERNAME;
            usuario.DS_PASSWORD = entity.DS_PASSWORD;

            Context.SaveChanges();
            return usuario;
        }

        public IEnumerable<TB_USUARIO> FindAlunosByNameOrMatricula(string nome, string matricula)
        {
            var usuarios = Context.TB_USUARIOS
                .Where(x => string.IsNullOrEmpty(nome) || x.DS_NOME.Contains(nome))
                .Where(x => string.IsNullOrEmpty(matricula) || x.MATRICULA.Equals(matricula))
                .ToList();

            var usuariosId = usuarios.Select(x => x.USUARIO_ID).ToArray();

            var roleAluno = (int)Common.Const.Roles.ALUNO;

            var rolesAlunos = Context.RL_USUARIO_ROLE
                .Where(x => usuariosId.Contains(x.FK_USUARIO_ID) && x.FK_ROLE_ID == roleAluno)
                .Select(x => x.FK_USUARIO_ID)
                .ToArray();

            return usuarios.Where(x => rolesAlunos.Contains(x.USUARIO_ID)).ToList();
        }

        public TB_USUARIO FindByUsernameAndPassword(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new SegurancaException(ExceptionMessages.UsuarioNaoEncontrado, new Exception($"Não foi encontrado nenhum registro com os seguintes dados: {username}"));

            var usuario = Context.TB_USUARIOS
                .SingleOrDefault(x => x.DS_USERNAME == username && x.DS_PASSWORD == password);

            if (usuario == null)
                throw new SegurancaException(ExceptionMessages.UsuarioNaoEncontrado, new Exception($"Não foi encontrado nenhum registro com os seguintes dados: {username}"));

            var roles = Context.RL_USUARIO_ROLE
                .Include(x => x.TB_ROLES)
                .Where(x => x.FK_USUARIO_ID == usuario.USUARIO_ID)
                .Select(x => x.TB_ROLES)
                .ToList();

            usuario.TB_USER_ROLES = roles;
            return usuario;
        }
    }
}