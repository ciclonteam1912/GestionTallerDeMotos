namespace GestionTallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaPersonerias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personerias",
                c => new
                    {
                        Codigo = c.Byte(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Codigo);
            
            AddColumn("dbo.Clientes", "PersoneriaCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.Clientes", "PersoneriaCodigo");
            AddForeignKey("dbo.Clientes", "PersoneriaCodigo", "dbo.Personerias", "Codigo", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "PersoneriaCodigo", "dbo.Personerias");
            DropIndex("dbo.Clientes", new[] { "PersoneriaCodigo" });
            DropColumn("dbo.Clientes", "PersoneriaCodigo");
            DropTable("dbo.Personerias");
        }
    }
}
