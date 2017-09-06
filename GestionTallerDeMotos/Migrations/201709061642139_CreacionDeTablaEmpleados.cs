namespace GestionTallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaEmpleados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Cedula = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(maxLength: 255),
                        Telefono = c.String(maxLength: 50),
                        CorreoElectronico = c.String(maxLength: 50),
                        FechaDeNacimiento = c.DateTime(),
                        HoraDeEntrada = c.String(maxLength: 10),
                        HoraDeSalida = c.String(maxLength: 10),
                        Salario = c.Int(nullable: false),
                        FechaDeIngreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empleados");
        }
    }
}
