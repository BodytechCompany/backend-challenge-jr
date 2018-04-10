namespace BT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogUrl : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Exercicios", newName: "FichaTreinoes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FichaTreinoes", newName: "Exercicios");
        }
    }
}
