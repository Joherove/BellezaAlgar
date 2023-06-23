using DTVentaAPI.Venta;

namespace DMVentaAPI.Venta
{
    public interface IDMVenta
    {
        IEnumerable<VentaDTO> Getventas();

        IEnumerable<VentaDTO> Postventa(VentaDTO venta); 
    } 
}
