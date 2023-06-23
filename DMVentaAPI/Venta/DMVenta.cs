using Dapper;
using DTVentaAPI.Venta;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DMVentaAPI.Venta
{
    public class DMVenta : IDMVenta
    {
        private readonly IConfiguration config; 
        private readonly string cadenaConexion;

        public DMVenta(IConfiguration config)
        {
            this.config = config;
            this.cadenaConexion = this.config.GetConnectionString("ConnectionBdBelleza");
        }

        public IEnumerable<VentaDTO> Getventas()
        {
            using (IDbConnection db = new SqlConnection(this.cadenaConexion))
            {
                var data = db.Query<VentaDTO>("dbo.usp_ConsultarProductos", commandType: CommandType.StoredProcedure);

                return data.ToList();
            }
        }

        public IEnumerable<VentaDTO> Postventa(VentaDTO venta)
        {
            using (IDbConnection db = new SqlConnection(this.cadenaConexion))
            {
                var data = db.Query<VentaDTO>("usp_GuardarCompra", param: new { venta.ProductoId, venta.Valor, venta.Nombre, venta.Direccion, venta.InventarioColoresId }, commandType: CommandType.StoredProcedure);

                return data.ToList(); 
            }
        }
    }    
}
