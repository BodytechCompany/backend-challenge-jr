namespace Bodytech.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_EXERCICIOS",
                c => new
                    {
                        EXERCICIO_ID = c.Int(nullable: false, identity: true),
                        NUM_ORDEM = c.Int(nullable: false),
                        DS_EXERCICIO = c.String(),
                        DS_REPETICAO = c.String(),
                        NUM_CARGA = c.Double(nullable: false),
                        FK_ALUNO_ID = c.Int(nullable: false),
                        FK_PROFESSOR_ID = c.Int(nullable: false),
                        DT_DATA_TREINO = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EXERCICIO_ID)
                .ForeignKey("dbo.TB_USUARIO", t => t.FK_ALUNO_ID)
                .ForeignKey("dbo.TB_USUARIO", t => t.FK_PROFESSOR_ID)
                .Index(t => t.FK_ALUNO_ID)
                .Index(t => t.FK_PROFESSOR_ID);
            
            CreateTable(
                "dbo.TB_USUARIO",
                c => new
                    {
                        USUARIO_ID = c.Int(nullable: false, identity: true),
                        DS_USERNAME = c.String(),
                        DS_PASSWORD = c.String(),
                        DS_NOME = c.String(),
                        MATRICULA = c.String(),
                    })
                .PrimaryKey(t => t.USUARIO_ID);
            
            CreateTable(
                "dbo.TB_ROLES",
                c => new
                    {
                        ROLE_ID = c.Int(nullable: false, identity: true),
                        DS_ROLE = c.String(),
                    })
                .PrimaryKey(t => t.ROLE_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_EXERCICIOS", "FK_PROFESSOR_ID", "dbo.TB_USUARIO");
            DropForeignKey("dbo.TB_EXERCICIOS", "FK_ALUNO_ID", "dbo.TB_USUARIO");
            DropIndex("dbo.TB_EXERCICIOS", new[] { "FK_PROFESSOR_ID" });
            DropIndex("dbo.TB_EXERCICIOS", new[] { "FK_ALUNO_ID" });
            DropTable("dbo.TB_ROLES");
            DropTable("dbo.TB_USUARIO");
            DropTable("dbo.TB_EXERCICIOS");
        }
    }
}
