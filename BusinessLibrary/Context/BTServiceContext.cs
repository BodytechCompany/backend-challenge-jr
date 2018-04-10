using System.Data.Entity;

namespace BusinessLibrary.Entity
{
    public class BTServiceContext : DbContext 
    {
        public BTServiceContext() : base("name=BTServiceContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<TipoMatricula> TipoMatriculas { get; set; }

    }
}