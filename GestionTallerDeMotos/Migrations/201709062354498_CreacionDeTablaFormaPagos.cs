namespace GestionTallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaFormaPagos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormaPagos",
                c => new
                    {
                        Codigo = c.Byte(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FormaPagos");
        }
    }
}
