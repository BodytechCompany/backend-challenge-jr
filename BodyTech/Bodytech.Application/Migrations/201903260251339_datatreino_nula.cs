namespace Bodytech.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatreino_nula : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_EXERCICIOS", "DT_DATA_TREINO", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_EXERCICIOS", "DT_DATA_TREINO", c => c.DateTime(nullable: false));
        }
    }
}
