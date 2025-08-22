using Examen22_08_25.Entidades;
using Examen22_08_25.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examen22_08_25.Controllers
{
    [Route("api/gruposmusica")]
    [ApiController]
    public class GruposMusicaController : ControllerBase
    {
        private readonly IGestionGruposMusica gestionGruposMusica;
        private readonly ILogger<GruposMusicaController> logger;

        const int TamañoPagina = 5;

        public GruposMusicaController(IGestionGruposMusica gestionGruposMusica, ILogger<GruposMusicaController> logger)
        {
            this.gestionGruposMusica = gestionGruposMusica;
            this.logger = logger;
        }

        // GET: api/gruposmusica
        [HttpGet]
        public async Task<ActionResult<List<GrupoMusica>>> Get([
            FromQuery] string? genero,
            [FromQuery] string? nombre,
            [FromQuery] int numeroPagina = 1,
            [FromQuery] int tamañoPagina = TamañoPagina)
        {
            var (grupos, totalRegistros) = await gestionGruposMusica.ObtenerTodosFiltrado(genero, nombre, numeroPagina, tamañoPagina);
            logger.LogInformation($"Obteniendo todos los grupos de música. Número de grupos: {totalRegistros}");
            return Ok(new { grupos, totalRegistros });
        }

        // GET: api/gruposmusica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoMusica>> Get([FromRoute] int id)
        {
            var grupo = await gestionGruposMusica.ObtenerPorId(id);
            if (grupo == null)
            {
                logger.LogError($"No se ha encontrado el grupo con id {id}");
                return NotFound();
            }
            return Ok(grupo);
        }

        // POST: api/gruposmusica
        [HttpPost]
        public async Task<ActionResult<GrupoMusica>> Post([FromBody] GrupoMusica grupo)
        {
            var modeloValido = ModelState.IsValid;
            modeloValido = TryValidateModel(grupo);
            if (!modeloValido)
            {
                return BadRequest(ModelState);
            }
            gestionGruposMusica.Agregar(grupo);
            await gestionGruposMusica.GuardarCambios();
            return CreatedAtAction(nameof(Get), new { id = grupo.Id }, grupo);
        }

        // PUT: api/gruposmusica/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] GrupoMusica grupo)
        {
            var grupoActual = await gestionGruposMusica.ObtenerPorId(id);
            if (grupoActual == null)
            {
                return NotFound();
            }
            grupoActual.Nombre = grupo.Nombre;
            grupoActual.Genero = grupo.Genero;
            grupoActual.NumeroIntegrantes = grupo.NumeroIntegrantes;
            grupoActual.FechaFormacion = grupo.FechaFormacion;
            grupoActual.Activo = grupo.Activo;
            gestionGruposMusica.ActualizarGrupo(grupoActual);
            await gestionGruposMusica.GuardarCambios();
            return NoContent();
        }

        // DELETE: api/gruposmusica/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var grupo = await gestionGruposMusica.ObtenerPorId(id);
            if (grupo == null)
            {
                return NotFound();
            }
            gestionGruposMusica.EliminarGrupo(grupo);
            await gestionGruposMusica.GuardarCambios();
            return Ok();
        }
    }
}
