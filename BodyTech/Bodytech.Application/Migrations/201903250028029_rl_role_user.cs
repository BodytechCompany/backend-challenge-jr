namespace Bodytech.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rl_role_user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RL_USUARIO_ROLE",
                c => new
                    {
                        RL_USUARIO_ROLE_ID = c.Int(nullable: false, identity: true),
                        FK_USUARIO_ID = c.Int(nullable: false),
                        FK_ROLE_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RL_USUARIO_ROLE_ID)
                .ForeignKey("dbo.TB_ROLES", t => t.FK_ROLE_ID)
                .ForeignKey("dbo.TB_USUARIO", t => t.FK_USUARIO_ID)
                .Index(t => t.FK_USUARIO_ID)
                .Index(t => t.FK_ROLE_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RL_USUARIO_ROLE", "FK_USUARIO_ID", "dbo.TB_USUARIO");
            DropForeignKey("dbo.RL_USUARIO_ROLE", "FK_ROLE_ID", "dbo.TB_ROLES");
            DropIndex("dbo.RL_USUARIO_ROLE", new[] { "FK_ROLE_ID" });
            DropIndex("dbo.RL_USUARIO_ROLE", new[] { "FK_USUARIO_ID" });
            DropTable("dbo.RL_USUARIO_ROLE");
        }
    }
}
