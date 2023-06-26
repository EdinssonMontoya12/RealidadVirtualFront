using ApiRealidadVirtual.Entidades;
using AutoMapper;

namespace ApiRealidadVirtual.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<Tercero, DtoConsultarTercero>();
            //CreateMap<DtoCrearTercero, Tercero>();

            CreateMap<Lenguaje, LenguajeConsultar>();
            CreateMap<LenguajeCreate, Lenguaje>();

            CreateMap<Anexo, AnexoConsultar>();
            CreateMap<AnexoCreate, Anexo>();

            CreateMap<Herammientum, HerammientumConsultar>();
            CreateMap<HerammientumCreate, Herammientum>();

        }
    }
}
