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

    public class UsuarioTareaController : ControllerBase
    {
        private UsuarioTareaBL usuarioTareaBL = new UsuarioTareaBL();

        [HttpGet]
        public async Task<IEnumerable<UsuarioTarea>> Get()
        {
            return await usuarioTareaBL.ObtenerTodosAsync();
        }

        [HttpGet("{idUsuarioTarea}")]
        public async Task<UsuarioTarea> Get(int idUsuarioTarea)
        {
            UsuarioTarea usuarioTarea = new UsuarioTarea();
            usuarioTarea.IdUsuarioTarea = idUsuarioTarea;
            return await usuarioTareaBL.ObtenerPorIdAsync(usuarioTarea);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioTarea usuarioTarea)
        {
            try
            {
                await usuarioTareaBL.CrearAsync(usuarioTarea);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int idUsuarioTarea, [FromBody] UsuarioTarea usuarioTarea)
        {
            if (usuarioTarea.IdUsuarioTarea == idUsuarioTarea)
            {
                await usuarioTareaBL.ModificarAsync(usuarioTarea);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idUsuarioTarea}")]
        public async Task<ActionResult> Delete(int idUsuarioTarea)
        {
            try
            {
                UsuarioTarea usuarioTarea = new UsuarioTarea();
                usuarioTarea.IdUsuarioTarea = idUsuarioTarea;
                await usuarioTareaBL.EliminarAsync(usuarioTarea);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<UsuarioTarea>> Buscar([FromBody] object pUsuarioTarea)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strUsuarioTarea = JsonSerializer.Serialize(pUsuarioTarea);
            UsuarioTarea usuarioTarea = JsonSerializer.Deserialize<UsuarioTarea>(strUsuarioTarea, option);
            return await usuarioTareaBL.BuscarAsync(usuarioTarea);
        }
    }
}
