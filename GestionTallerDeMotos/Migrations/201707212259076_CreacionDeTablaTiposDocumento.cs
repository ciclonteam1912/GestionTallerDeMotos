namespace GestionTallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionDeTablaTiposDocumento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TiposDocumento",
                c => new
                    {
                        Codigo = c.Byte(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Codigo);
            
            AddColumn("dbo.Clientes", "TipoDocumentoCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.Clientes", "TipoDocumentoCodigo");
            AddForeignKey("dbo.Clientes", "TipoDocumentoCodigo", "dbo.TiposDocumento", "Codigo", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "TipoDocumentoCodigo", "dbo.TiposDocumento");
            DropIndex("dbo.Clientes", new[] { "TipoDocumentoCodigo" });
            DropColumn("dbo.Clientes", "TipoDocumentoCodigo");
            DropTable("dbo.TiposDocumento");
        }
    }
}
