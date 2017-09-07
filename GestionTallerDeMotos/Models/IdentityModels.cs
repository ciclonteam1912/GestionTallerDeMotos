using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using GestionTallerDeMotos.ConfiguracionDeEntidades;

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
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Combustible> Combustibles { get; set; }
        public DbSet<Aseguradora> Aseguradoras { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<PresupuestoDetalle> PresupuestoDetalles { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<FormaPago> FormaPagos { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ClienteConfiguracion());
            modelBuilder.Configurations.Add(new PersoneriaConfiguracion());
            modelBuilder.Configurations.Add(new TipoDocumentoConfiguracion());
            modelBuilder.Configurations.Add(new MarcaConfiguracion());
            modelBuilder.Configurations.Add(new ModeloConfiguracion());
            modelBuilder.Configurations.Add(new CombustibleConfiguracion());
            modelBuilder.Configurations.Add(new AseguradoraConfiguracion());
            modelBuilder.Configurations.Add(new VehiculoConfiguracion());
            modelBuilder.Configurations.Add(new ProveedorConfiguracion());
            modelBuilder.Configurations.Add(new ProductoConfiguracion());
            modelBuilder.Configurations.Add(new PresupuestoConfiguracion());
            modelBuilder.Configurations.Add(new PresupuestoDetalleConfiguracion());
            modelBuilder.Configurations.Add(new EstadoConfiguracion());
            modelBuilder.Configurations.Add(new EmpleadoConfiguracion());
            modelBuilder.Configurations.Add(new CargoConfiguracion());
            modelBuilder.Configurations.Add(new FormaPagoConfiguracion());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}