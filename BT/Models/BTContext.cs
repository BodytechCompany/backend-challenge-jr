using BT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BtTraining.Models
{
    public class BTContext : DbContext
    {
        public BTContext() : base("name=BTContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<TipoMatricula> TipoMatriculas { get; set; }

        public System.Data.Entity.DbSet<BusinessLibrary.Entity.Exercicio> Exercicios { get; set; }

        public System.Data.Entity.DbSet<BusinessLibrary.Entity.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<BusinessLibrary.Entity.Professor> Professors { get; set; }
    }
}