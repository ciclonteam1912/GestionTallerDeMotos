namespace GestionTallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CargarDatosEnLasTablasPersoneriasYTiposDocumento : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Personerias (Descripcion) VALUES ('Física')");
            Sql("INSERT INTO Personerias (Descripcion) VALUES ('Jurídica')");

            Sql("INSERT INTO TiposDocumento (Descripcion) VALUES ('Cédula')");
            Sql("INSERT INTO TiposDocumento (Descripcion) VALUES ('RUC')");
            Sql("INSERT INTO TiposDocumento (Descripcion) VALUES ('Pasaporte')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Personerias WHERE Descripcion IN ('Física', 'Jurídica')");
            Sql("DELETE FROM TiposDocumento WHERE Descripcion IN ('Cédula', 'RUC', 'Pasaporte')");
        }
    }
}
