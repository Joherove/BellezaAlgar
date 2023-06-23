using DTVentaAPI.Venta;

namespace BMVentaAPI.Venta
{
    public interface IBMVenta
    {
        IEnumerable<VentaDTO> Getventas();

        IEnumerable<VentaDTO> Postventa(VentaDTO venta);
    }
}