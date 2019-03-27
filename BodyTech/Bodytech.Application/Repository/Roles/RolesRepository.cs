using Bodytech.Application.Common.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodytech.Application.Repository.Roles
{
    public class RolesRepository : IRolesRepository
    {
        private readonly BodyTechContext Context;

        public RolesRepository(BodyTechContext context)
        {
            Context = context;
        }

        public TB_ROLES Add(TB_ROLES entity)
        {
            entity = Context.TB_ROLES.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public void Delete(int Id)
        {
            var role = Context.TB_ROLES.SingleOrDefault(x => x.ROLE_ID == Id);
            if (role == null)
                throw new Exception(ExceptionMessages.RoleNaoCadastrada);

            Context.TB_ROLES.Remove(role);
            Context.SaveChanges();
        }

        public TB_ROLES Find(int Id)
        {
            return Context.TB_ROLES.SingleOrDefault(x => x.ROLE_ID == Id);
        }

        public IEnumerable<TB_ROLES> Get()
        {
            return Context.TB_ROLES.ToList();
        }

        public TB_ROLES Update(TB_ROLES entity)
        {
            var role = Context.TB_ROLES.SingleOrDefault(x => x.ROLE_ID == entity.ROLE_ID);
            if (role == null)
                throw new Exception(ExceptionMessages.RoleNaoCadastrada);

            role.DS_ROLE = entity.DS_ROLE;
            Context.SaveChanges();

            return role;
        }
    }
}