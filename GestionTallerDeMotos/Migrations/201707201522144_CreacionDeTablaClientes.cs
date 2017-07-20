namespace GestionTallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaClientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(maxLength: 50),
                        Telefono = c.String(maxLength: 50),
                        Direccion = c.String(maxLength: 255),
                        CorreoElectronico = c.String(maxLength: 50),
                        NombrePropietario = c.String(maxLength: 50),
                        FechaDeNacimiento = c.DateTime(),
                        FechaDeIngreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
