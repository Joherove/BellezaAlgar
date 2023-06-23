using AutoMapper;
using DTVentaAPI.Venta;

namespace DTDemoAPI.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VentaDTO, SolicitudVenta>().ReverseMap();
            CreateMap<RespuestaVenta, VentaDTO>().ReverseMap(); 
        }
    }
}
