namespace GestionTallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaProductos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Marca = c.String(maxLength: 20),
                        PrecioCosto = c.Int(nullable: false),
                        PrecioVenta = c.Int(nullable: false),
                        ExistenciaActual = c.Int(nullable: false),
                        ExistenciaMinima = c.Int(nullable: false),
                        ProveedorCodigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Proveedores", t => t.ProveedorCodigo, cascadeDelete: true)
                .Index(t => t.ProveedorCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "ProveedorCodigo", "dbo.Proveedores");
            DropIndex("dbo.Productos", new[] { "ProveedorCodigo" });
            DropTable("dbo.Productos");
        }
    }
}
