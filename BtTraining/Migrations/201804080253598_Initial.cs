namespace BtTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        clie_id = c.Int(nullable: false, identity: true),
                        clie_nm_nome = c.String(nullable: false),
                        clie_nr_matricula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.clie_id);
            
            CreateTable(
                "dbo.Exercicios",
                c => new
                    {
                        Exer_id = c.Int(nullable: false, identity: true),
                        exer_nr_ordem = c.Int(nullable: false),
                        clie_id = c.Int(nullable: false),
                        exer_nm_nome = c.String(nullable: false),
                        exer_nm_repeticao = c.String(),
                        exer_db_carga = c.Int(nullable: false),
                        prof_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Exer_id)
                .ForeignKey("dbo.Clientes", t => t.clie_id, cascadeDelete: true)
                .ForeignKey("dbo.Professors", t => t.prof_id, cascadeDelete: true)
                .Index(t => t.clie_id)
                .Index(t => t.prof_id);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        prof_id = c.Int(nullable: false, identity: true),
                        prof_nm_nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.prof_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercicios", "prof_id", "dbo.Professors");
            DropForeignKey("dbo.Exercicios", "clie_id", "dbo.Clientes");
            DropIndex("dbo.Exercicios", new[] { "prof_id" });
            DropIndex("dbo.Exercicios", new[] { "clie_id" });
            DropTable("dbo.Professors");
            DropTable("dbo.Exercicios");
            DropTable("dbo.Clientes");
        }
    }
}
