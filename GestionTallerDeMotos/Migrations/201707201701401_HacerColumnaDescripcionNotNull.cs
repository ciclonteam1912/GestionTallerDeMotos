namespace GestionTallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HacerColumnaDescripcionNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TiposDocumento", "Descripcion", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TiposDocumento", "Descripcion", c => c.String(maxLength: 50));
        }
    }
}
