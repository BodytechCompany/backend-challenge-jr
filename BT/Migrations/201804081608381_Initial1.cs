namespace BT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logins", "tipoMatricula_TipoMatricula_id", "dbo.TipoMatriculas");
            DropIndex("dbo.Logins", new[] { "tipoMatricula_TipoMatricula_id" });
            RenameColumn(table: "dbo.Logins", name: "tipoMatricula_TipoMatricula_id", newName: "TipoMatricula_id");
            AlterColumn("dbo.Logins", "TipoMatricula_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Logins", "TipoMatricula_id");
            AddForeignKey("dbo.Logins", "TipoMatricula_id", "dbo.TipoMatriculas", "TipoMatricula_id", cascadeDelete: true);
            DropColumn("dbo.Logins", "Tipo_Matricula_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "Tipo_Matricula_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Logins", "TipoMatricula_id", "dbo.TipoMatriculas");
            DropIndex("dbo.Logins", new[] { "TipoMatricula_id" });
            AlterColumn("dbo.Logins", "TipoMatricula_id", c => c.Int());
            RenameColumn(table: "dbo.Logins", name: "TipoMatricula_id", newName: "tipoMatricula_TipoMatricula_id");
            CreateIndex("dbo.Logins", "tipoMatricula_TipoMatricula_id");
            AddForeignKey("dbo.Logins", "tipoMatricula_TipoMatricula_id", "dbo.TipoMatriculas", "TipoMatricula_id");
        }
    }
}
