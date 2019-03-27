using Bodytech.Application.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Bodytech.Application.Repository
{
    /// <summary>
    /// Construtor do banco de dados
    /// </summary>
    public class BodyTechContext : DbContext
    {
        public DbSet<TB_USUARIO> TB_USUARIOS { get; set; }
        public DbSet<TB_ROLES> TB_ROLES { get; set; }
        public DbSet<TB_EXERCICIOS> TB_EXERCICIOS { get; set; }
        public DbSet<RL_USUARIO_ROLE> RL_USUARIO_ROLE { get; set; }

        public BodyTechContext()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}