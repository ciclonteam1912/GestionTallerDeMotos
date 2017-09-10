namespace GestionTallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CargarUsuarioYRolPorDefecto : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'22e77d38-cb84-401d-ae21-48335197698d', N'admingtmpedrozo@gmail.com', 0, N'AGEb4ef7Qzey7F+I1ovA0tGe0L4bjKPhKZKUyN2i8wjp6zwEY1fU1lWNukkoS+bArQ==', N'51939bf6-bd9e-48eb-85b2-31f591aa9a9a', NULL, 0, 0, NULL, 1, 0, N'admin')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4cc9d923-926d-428c-8f45-2bb6e4b215f0', N'Administrador')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'22e77d38-cb84-401d-ae21-48335197698d', N'4cc9d923-926d-428c-8f45-2bb6e4b215f0')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
