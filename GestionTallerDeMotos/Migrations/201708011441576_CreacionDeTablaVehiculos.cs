namespace GestionTallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionDeTablaVehiculos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehiculoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Matricula = c.String(nullable: false, maxLength: 20),
                        Chasis = c.String(maxLength: 20),
                        Kilometro = c.Single(nullable: false),
                        Motor = c.String(maxLength: 20),
                        Cilindrada = c.Int(nullable: false),
                        FechaDeIngreso = c.DateTime(nullable: false),
                        Color = c.String(maxLength: 20),
                        ModeloCodigo = c.Byte(nullable: false),
                        ClienteCodigo = c.Int(nullable: false),
                        CombustibleCodigo = c.Byte(nullable: false),
                        AseguradoraCodigo = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Aseguradoras", t => t.AseguradoraCodigo, cascadeDelete: true)
                .ForeignKey("dbo.Clientes", t => t.ClienteCodigo, cascadeDelete: true)
                .ForeignKey("dbo.Combustibles", t => t.CombustibleCodigo, cascadeDelete: true)
                .ForeignKey("dbo.Modelos", t => t.ModeloCodigo, cascadeDelete: true)
                .Index(t => t.ModeloCodigo)
                .Index(t => t.ClienteCodigo)
                .Index(t => t.CombustibleCodigo)
                .Index(t => t.AseguradoraCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculoes", "ModeloCodigo", "dbo.Modelos");
            DropForeignKey("dbo.Vehiculoes", "CombustibleCodigo", "dbo.Combustibles");
            DropForeignKey("dbo.Vehiculoes", "ClienteCodigo", "dbo.Clientes");
            DropForeignKey("dbo.Vehiculoes", "AseguradoraCodigo", "dbo.Aseguradoras");
            DropIndex("dbo.Vehiculoes", new[] { "AseguradoraCodigo" });
            DropIndex("dbo.Vehiculoes", new[] { "CombustibleCodigo" });
            DropIndex("dbo.Vehiculoes", new[] { "ClienteCodigo" });
            DropIndex("dbo.Vehiculoes", new[] { "ModeloCodigo" });
            DropTable("dbo.Vehiculoes");
        }
    }
}
