using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models.ModelosDeDominio;

namespace GestionTallerDeMotos.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Cliente, ClienteDto>();
            Mapper.CreateMap<Personeria, PersoneriaDto>();
            Mapper.CreateMap<TipoDocumento, TipoDocumentoDto>();
        }
    }
}