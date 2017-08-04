namespace GestionTallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiarLongitudDeColumnaMarcaEnTablaProductos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productos", "Marca", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productos", "Marca", c => c.String(maxLength: 20));
        }
    }
}
