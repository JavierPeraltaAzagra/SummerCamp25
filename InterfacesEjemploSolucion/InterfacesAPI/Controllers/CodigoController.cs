using InterfacesEjemploProyecto.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterfacesAPI.Controllers
{
    [Route("api/codigo")]
    [ApiController]
    public class CodigoController : ControllerBase
    {
        private ICodigoGenerador _codigoGenerador;

        public CodigoController(ICodigoGenerador codigo)
        {
            _codigoGenerador = codigo; // Inyección de dependencia   
        }

        [HttpGet("{prefijo}")]
        public IActionResult Get(string prefijo)
        {
            return Ok(_codigoGenerador.GenerarCodigo(prefijo));
        }
    }
}
