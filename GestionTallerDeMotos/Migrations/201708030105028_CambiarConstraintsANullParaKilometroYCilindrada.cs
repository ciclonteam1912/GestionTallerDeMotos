namespace GestionTallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiarConstraintsANullParaKilometroYCilindrada : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehiculos", "Kilometro", c => c.Single());
            AlterColumn("dbo.Vehiculos", "Cilindrada", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehiculos", "Cilindrada", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehiculos", "Kilometro", c => c.Single(nullable: false));
        }
    }
}
