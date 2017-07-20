using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GestionTallerDeMotos.Models.ModelosDeDominio;

namespace GestionTallerDeMotos.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Personeria> Personerias { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Id)
                .HasColumnName("Codigo");


            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Apellido)
                .HasMaxLength(50);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Direccion)
                .HasMaxLength(255);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Telefono)
                .HasMaxLength(50);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.CorreoElectronico)
                .HasMaxLength(50);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.NombrePropietario)
                .HasMaxLength(50);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.PersoneriaId)
                .HasColumnName("PersoneriaCodigo");

            modelBuilder.Entity<Cliente>()
                .Property(c => c.TipoDocumentoId)
                .HasColumnName("TipoDocumentoCodigo");

            modelBuilder.Entity<Personeria>()
                .Property(p => p.Id)
                .HasColumnName("Codigo");

            modelBuilder.Entity<Personeria>()
                .Property(p => p.Descripcion)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<TipoDocumento>()
                .ToTable("TiposDocumento");

            modelBuilder.Entity<TipoDocumento>()
                .Property(tp => tp.Id)
                .HasColumnName("Codigo");

            modelBuilder.Entity<TipoDocumento>()
                .Property(tp => tp.Descripcion)
                .IsRequired()
                .HasMaxLength(50);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}