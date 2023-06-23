namespace DTVentaAPI.Venta
{
    public class VentaDTO
    {
        public int ProductoId { get; set; }        
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int InventarioColoresId { get; set; }
        
        public string Descripcion { get; set; }
        public int Valor { get; set; }        
        public string Color { get; set; }
        public int Cantidad { get; set; }  
    }
}
