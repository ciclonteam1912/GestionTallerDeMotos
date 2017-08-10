namespace GestionTallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarColumnaIdentityATablaPresupuestoDetalles : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PresupuestoDetalles");
            AlterColumn("dbo.PresupuestoDetalles", "Codigo", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PresupuestoDetalles", new[] { "Codigo", "PresupuestoCodigo", "ProductoCodigo" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PresupuestoDetalles");
            AlterColumn("dbo.PresupuestoDetalles", "Codigo", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PresupuestoDetalles", new[] { "Codigo", "PresupuestoCodigo", "ProductoCodigo" });
        }
    }
}
