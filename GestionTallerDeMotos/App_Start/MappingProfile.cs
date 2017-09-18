using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models.ModelosDeDominio;

namespace GestionTallerDeMotos.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Dominio a Dominio
            Mapper.CreateMap<Cliente, Cliente>()
                .ForMember(c => c.FechaDeIngreso, opt => opt.Ignore());
            Mapper.CreateMap<Marca, Marca>();
            Mapper.CreateMap<Combustible, Combustible>();
            Mapper.CreateMap<Aseguradora, Aseguradora>();
            Mapper.CreateMap<Vehiculo, Vehiculo>()
                .ForMember(v => v.FechaDeIngreso, opt => opt.Ignore());
            Mapper.CreateMap<Proveedor, Proveedor>();
            Mapper.CreateMap<Producto, Producto>();
            Mapper.CreateMap<Empleado, Empleado>()
                .ForMember(e => e.FechaDeIngreso, opt => opt.Ignore());
            Mapper.CreateMap<FormaPago, FormaPago>();
            Mapper.CreateMap<ServicioBasico, ServicioBasico>();
            Mapper.CreateMap<Talonario, Talonario>();

            //Dominio a DTO
            Mapper.CreateMap<Cliente, ClienteDto>();
            Mapper.CreateMap<Personeria, PersoneriaDto>();
            Mapper.CreateMap<TipoDocumento, TipoDocumentoDto>();            
            Mapper.CreateMap<Marca, MarcaDto>();
            Mapper.CreateMap<Modelo, ModeloDto>();            
            Mapper.CreateMap<Combustible, CombustibleDto>();            
            Mapper.CreateMap<Aseguradora, AseguradoraDto>();            
            Mapper.CreateMap<Vehiculo, VehiculoDto>();            
            Mapper.CreateMap<Proveedor, ProveedorDto>();            
            Mapper.CreateMap<Producto, ProductoDto>();            
            Mapper.CreateMap<Empleado, EmpleadoDto>();            
            Mapper.CreateMap<FormaPago, FormaPagoDto>();            
            Mapper.CreateMap<ServicioBasico, ServicioBasicoDto>();

            //DTO a Dominio
            Mapper.CreateMap<MarcaDto, Marca>();
            Mapper.CreateMap<ModeloDto, Modelo>();
            Mapper.CreateMap<CombustibleDto, Combustible>();
            Mapper.CreateMap<AseguradoraDto, Aseguradora>();
            Mapper.CreateMap<VehiculoDto, Vehiculo>()
                .ForMember(v => v.FechaDeIngreso, opt => opt.Ignore());
            Mapper.CreateMap<ProveedorDto, Proveedor>();
            Mapper.CreateMap<ProductoDto, Producto>();
            Mapper.CreateMap<PresupuestoDto, Presupuesto>();
            Mapper.CreateMap<PresupuestoDetalleDto, PresupuestoDetalle>();
            Mapper.CreateMap<EmpleadoDto, Empleado>();
            Mapper.CreateMap<FormaPagoDto, FormaPago>();
            Mapper.CreateMap<ServicioBasicoDto, ServicioBasico>();
        }
    }
}