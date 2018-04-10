namespace BtTraining.Migrations
{
    using BusinessLibrary.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BTServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(BTServiceContext context)
        {
            //  This method will be called after migrating to the latest version.
            try
            {
                context.Clientes.AddOrUpdate(x => x.clie_id,
                                new Cliente() { clie_id = 1, clie_nm_nome = "Jane Austen",clie_nr_matricula = 070420181 },
                                new Cliente() { clie_id = 2, clie_nm_nome = "Charles Dickens", clie_nr_matricula = 070420182 }
                                );

                context.Professors.AddOrUpdate(x => x.prof_id,
                    new Professor()
                    {
                        prof_id = 1,
                        prof_nm_nome = "Professor 1"
                      
                    },
                    new Professor()
                    {
                        prof_id = 2,
                        prof_nm_nome = "Professor 2"

                    }
                     );
            }
            catch (Exception)
            {

                throw;
            }
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
