using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GestorDeProyectos.EntidadesDeNegocio;
using GestorDeProyectos.EntidadesDeNegocio.Paginación;
using GestorDeProyectos.LogicaDeNegocios;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace GestorDeProyectos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class EquipoController : ControllerBase
    {
        private EquipoBL equipoBL = new EquipoBL();

        [HttpGet("paginated")]
        public async Task<ListPagEquipo> ListPagEquipo(int page = 1, int pageSize = 5, string equipo = "", string usuario = "")
        {
            return await equipoBL.ListPagEquipo(page, pageSize, equipo, usuario);
        }

        [HttpGet]
        public async Task<IEnumerable<Equipo>> Get()
        {
            return await equipoBL.ObtenerTodosAsync();
        }

        [HttpGet("{idEquipo}")]
        public async Task<Equipo> Get(int idEquipo)
        {
            Equipo equipo = new Equipo();
            equipo.IdEquipo = idEquipo;
            return await equipoBL.ObtenerPorIdAsync(equipo);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Equipo equipo)
        {
            try
            {
                await equipoBL.CrearAsync(equipo);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int idEquipo, [FromBody] Equipo equipo)
        {
            if (equipo.IdEquipo == idEquipo)
            {
                await equipoBL.ModificarAsync(equipo);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idEquipo}")]
        public async Task<ActionResult> Delete(int idEquipo)
        {
            try
            {
                Equipo equipo = new Equipo();
                equipo.IdEquipo = idEquipo;
                await equipoBL.EliminarAsync(equipo);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Equipo>> Buscar([FromBody] object pEquipo)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strEquipo = JsonSerializer.Serialize(pEquipo);
            Equipo equipo = JsonSerializer.Deserialize<Equipo>(strEquipo, option);
            return await equipoBL.BuscarAsync(equipo);
        }
    }
}
