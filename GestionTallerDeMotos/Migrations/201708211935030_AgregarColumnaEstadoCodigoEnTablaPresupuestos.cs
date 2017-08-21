namespace GestionTallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarColumnaEstadoCodigoEnTablaPresupuestos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Presupuestos", "EstadoCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.Presupuestos", "EstadoCodigo");
            AddForeignKey("dbo.Presupuestos", "EstadoCodigo", "dbo.Estados", "Codigo", cascadeDelete: true);
            DropColumn("dbo.Presupuestos", "PresupuestoAceptado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Presupuestos", "PresupuestoAceptado", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Presupuestos", "EstadoCodigo", "dbo.Estados");
            DropIndex("dbo.Presupuestos", new[] { "EstadoCodigo" });
            DropColumn("dbo.Presupuestos", "EstadoCodigo");
        }
    }
}
