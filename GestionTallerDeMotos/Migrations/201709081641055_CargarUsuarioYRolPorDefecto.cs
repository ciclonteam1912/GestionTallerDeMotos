namespace GestionTallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CargarUsuarioYRolPorDefecto : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e4ff2490-63f6-43f0-94b9-e6a870794ca6', N'admingtmpedrozo@gmail.com', 0, N'APr3W9nc0q21JwgkB6LeWrpwJlaoGeSP/WwWRfVtVZrW7UfFMsA/wojan6wTY7Uecw==', N'a5b16e7d-3a6b-404d-9c4f-13316bc57ff1', NULL, 0, 0, NULL, 1, 0, N'admingtmpedrozo@gmail.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'730ae0e9-0645-4a04-a794-4d4b5d544ef7', N'Administrador')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e4ff2490-63f6-43f0-94b9-e6a870794ca6', N'730ae0e9-0645-4a04-a794-4d4b5d544ef7')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
