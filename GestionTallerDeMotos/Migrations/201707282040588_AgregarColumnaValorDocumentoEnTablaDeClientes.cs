namespace GestionTallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarColumnaValorDocumentoEnTablaDeClientes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "ValorDocumento", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "ValorDocumento");
        }
    }
}
