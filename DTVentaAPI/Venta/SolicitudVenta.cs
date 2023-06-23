namespace DTVentaAPI.Venta
{
    public class SolicitudVenta
    {
        public int productoId { get; set; }
        public int valor { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }      
        public int inventarioColoresId { get; set; }  
    }
}
