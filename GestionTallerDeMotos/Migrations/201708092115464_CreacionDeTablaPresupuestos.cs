namespace GestionTallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionDeTablaPresupuestos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Presupuestos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        FechaEmision = c.DateTime(nullable: false),
                        VehiculoCodigo = c.Int(nullable: false),
                        PresupuestoAceptado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Vehiculos", t => t.VehiculoCodigo, cascadeDelete: true)
                .Index(t => t.VehiculoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Presupuestos", "VehiculoCodigo", "dbo.Vehiculos");
            DropIndex("dbo.Presupuestos", new[] { "VehiculoCodigo" });
            DropTable("dbo.Presupuestos");
        }
    }
}
