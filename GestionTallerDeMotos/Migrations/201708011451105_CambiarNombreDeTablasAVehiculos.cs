namespace GestionTallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiarNombreDeTablasAVehiculos : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Vehiculoes", newName: "Vehiculos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Vehiculos", newName: "Vehiculoes");
        }
    }
}
