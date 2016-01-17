namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoAtributoEndereco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contatoes", "Endereco", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contatoes", "Endereco");
        }
    }
}
