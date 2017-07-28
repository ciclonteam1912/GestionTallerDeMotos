namespace GestionTallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CargarDatosEnLasTablasPersoneriasYTiposDocumento : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Personerias (Descripcion) VALUES ('F�sica')");
            Sql("INSERT INTO Personerias (Descripcion) VALUES ('Jur�dica')");

            Sql("INSERT INTO TiposDocumento (Descripcion) VALUES ('C�dula')");
            Sql("INSERT INTO TiposDocumento (Descripcion) VALUES ('RUC')");
            Sql("INSERT INTO TiposDocumento (Descripcion) VALUES ('Pasaporte')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Personerias WHERE Descripcion IN ('F�sica', 'Jur�dica')");
            Sql("DELETE FROM TiposDocumento WHERE Descripcion IN ('C�dula', 'RUC', 'Pasaporte')");
        }
    }
}
