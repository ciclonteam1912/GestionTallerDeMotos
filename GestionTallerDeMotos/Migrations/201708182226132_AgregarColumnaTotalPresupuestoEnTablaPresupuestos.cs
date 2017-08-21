namespace GestionTallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarColumnaTotalPresupuestoEnTablaPresupuestos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Presupuestos", "TotalPresupuesto", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Presupuestos", "TotalPresupuesto");
        }
    }
}
