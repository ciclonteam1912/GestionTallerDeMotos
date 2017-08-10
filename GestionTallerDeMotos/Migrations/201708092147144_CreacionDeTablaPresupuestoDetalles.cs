namespace GestionTallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaPresupuestoDetalles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PresupuestoDetalles",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        PresupuestoCodigo = c.Int(nullable: false),
                        ProductoCodigo = c.Int(nullable: false),
                        Cantidad = c.Byte(nullable: false),
                        Precio = c.Int(nullable: false),
                        Iva = c.Int(nullable: false),
                        SubTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Codigo, t.PresupuestoCodigo, t.ProductoCodigo })
                .ForeignKey("dbo.Presupuestos", t => t.PresupuestoCodigo, cascadeDelete: true)
                .ForeignKey("dbo.Productos", t => t.ProductoCodigo, cascadeDelete: true)
                .Index(t => t.PresupuestoCodigo)
                .Index(t => t.ProductoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PresupuestoDetalles", "ProductoCodigo", "dbo.Productos");
            DropForeignKey("dbo.PresupuestoDetalles", "PresupuestoCodigo", "dbo.Presupuestos");
            DropIndex("dbo.PresupuestoDetalles", new[] { "ProductoCodigo" });
            DropIndex("dbo.PresupuestoDetalles", new[] { "PresupuestoCodigo" });
            DropTable("dbo.PresupuestoDetalles");
        }
    }
}
