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

    public class TipoRolController : ControllerBase
    {
        private TipoRolBL tipoRolBL = new TipoRolBL();

        [HttpGet]
        public async Task<IEnumerable<TipoRol>> Get()
        {
            return await tipoRolBL.ObtenerTodosAsync();
        }

        [HttpGet("{idTipoRol}")]
        public async Task<TipoRol> Get(int idTipoRol)
        {
            TipoRol tipoRol = new TipoRol();
            tipoRol.IdTipoRol = idTipoRol;
            return await tipoRolBL.ObtenerPorIdAsync(tipoRol);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoRol tipoRol)
        {
            try
            {
                await tipoRolBL.CrearAsync(tipoRol);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int idTipoRol, [FromBody] TipoRol tipoRol)
        {
            if (tipoRol.IdTipoRol == idTipoRol)
            {
                await tipoRolBL.ModificarAsync(tipoRol);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idTipoRol}")]
        public async Task<ActionResult> Delete(int idTipoRol)
        {
            try
            {
                TipoRol tipoRol = new TipoRol();
                tipoRol.IdTipoRol = idTipoRol;
                await tipoRolBL.EliminarAsync(tipoRol);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<TipoRol>> Buscar([FromBody] object pTipoRol)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strTipoRol = JsonSerializer.Serialize(pTipoRol);
            TipoRol tipoRol = JsonSerializer.Deserialize<TipoRol>(strTipoRol, option);
            return await tipoRolBL.BuscarAsync(tipoRol);
        }
    }
}
