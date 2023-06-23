using DMVentaAPI.Venta;
using DTVentaAPI.Venta;

namespace BMVentaAPI.Venta
{
    public class BMVenta : IBMVenta
    {
        private readonly IDMVenta dMVenta;

        public BMVenta(IDMVenta dMVenta)
        {
            this.dMVenta = dMVenta;
        }
        public IEnumerable<VentaDTO> Getventas()
        {
            return this.dMVenta.Getventas();
        }

        public IEnumerable<VentaDTO> Postventa(VentaDTO venta)
        {
            return this.dMVenta.Postventa(venta);
        }
    }
}
