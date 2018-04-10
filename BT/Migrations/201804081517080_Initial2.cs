namespace BT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula_Usuario = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Tipo_Matricula_id = c.Int(nullable: false),
                        tipoMatricula_TipoMatricula_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoMatriculas", t => t.tipoMatricula_TipoMatricula_id)
                .Index(t => t.tipoMatricula_TipoMatricula_id);
            
            CreateTable(
                "dbo.TipoMatriculas",
                c => new
                    {
                        TipoMatricula_id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TipoMatricula_id);
            
            DropTable("dbo.Usuarios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatriculaUsuario = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Logins", "tipoMatricula_TipoMatricula_id", "dbo.TipoMatriculas");
            DropIndex("dbo.Logins", new[] { "tipoMatricula_TipoMatricula_id" });
            DropTable("dbo.TipoMatriculas");
            DropTable("dbo.Logins");
        }
    }
}
