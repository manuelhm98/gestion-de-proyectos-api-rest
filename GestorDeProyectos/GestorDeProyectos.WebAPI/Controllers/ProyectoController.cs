using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GestorDeProyectos.EntidadesDeNegocio;
using GestorDeProyectos.LogicaDeNegocios;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace GestorDeProyectos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProyectoController : ControllerBase
    {
        private ProyectoBL proyectoBL = new ProyectoBL();

        [HttpGet]
        public async Task<IEnumerable<Proyecto>> Get()
        {
            return await proyectoBL.ObtenerTodosAsync();
        }

        [HttpGet("{idProyecto}")]
        public async Task<Proyecto> Get(int idProyecto)
        {
            Proyecto proyecto = new Proyecto();
            proyecto.IdProyecto = idProyecto;
            return await proyectoBL.ObtenerPorIdAsync(proyecto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Proyecto proyecto)
        {
            try
            {
                await proyectoBL.CrearAsync(proyecto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int idProyecto, [FromBody] Proyecto proyecto)
        {
            if (proyecto.IdProyecto == idProyecto)
            {
                await proyectoBL.ModificarAsync(proyecto);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idProyecto}")]
        public async Task<ActionResult> Delete(int idProyecto)
        {
            try
            {
                Proyecto proyecto = new Proyecto();
                proyecto.IdProyecto = idProyecto;
                await proyectoBL.EliminarAsync(proyecto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Proyecto>> Buscar([FromBody] object pProyecto)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strProyecto = JsonSerializer.Serialize(pProyecto);
            Proyecto proyecto = JsonSerializer.Deserialize<Proyecto>(strProyecto, option);
            return await proyectoBL.BuscarAsync(proyecto);
        }
    }
}
