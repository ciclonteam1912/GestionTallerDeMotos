namespace GestionTallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaCargos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargos",
                c => new
                    {
                        Codigo = c.Byte(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Codigo);
            
            AddColumn("dbo.Empleados", "CargoCodigo", c => c.Byte());
            CreateIndex("dbo.Empleados", "CargoCodigo");
            AddForeignKey("dbo.Empleados", "CargoCodigo", "dbo.Cargos", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleados", "CargoCodigo", "dbo.Cargos");
            DropIndex("dbo.Empleados", new[] { "CargoCodigo" });
            DropColumn("dbo.Empleados", "CargoCodigo");
            DropTable("dbo.Cargos");
        }
    }
}
