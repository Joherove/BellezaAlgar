using AutoMapper;
using BMVentaAPI.Venta;
using DTVentaAPI.Venta;
using Microsoft.AspNetCore.Mvc;

namespace VentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly ILogger<VentaController> _logger;
        private readonly IBMVenta bMVenta;
        private readonly IMapper mapper;

        public VentaController(ILogger<VentaController> logger, IMapper mapper, IBMVenta bMVenta)
        {
            _logger = logger;
            this.mapper = mapper;
            this.bMVenta = bMVenta;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RespuestaVenta>> Get()
        {                          
            var data = this.bMVenta.Getventas();
            var response = this.mapper.Map<IEnumerable<RespuestaVenta>>(data);

            return this.Ok(response);
                     
        }

        [HttpPost]
        public ActionResult<IEnumerable<RespuestaVenta>> Post([FromBody] SolicitudVenta request)
        {
            var ventaDTO = this.mapper.Map<VentaDTO>(request);
            var data = this.bMVenta.Postventa(ventaDTO);
            var response = this.mapper.Map<IEnumerable<RespuestaVenta>>(data);

            return this.Ok(response);
        }
    }    
}
