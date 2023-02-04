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

    public class TareaController : ControllerBase
    {
        private TareaBL tareaBL = new TareaBL();

        [HttpGet]
        public async Task<IEnumerable<Tarea>> Get()
        {
            return await tareaBL.ObtenerTodosAsync();
        }

        [HttpGet("{idTarea}")]
        public async Task<Tarea> Get(int idTarea)
        {
            Tarea tarea = new Tarea();
            tarea.IdTarea = idTarea;
            return await tareaBL.ObtenerPorIdAsync(tarea);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Tarea tarea)
        {
            try
            {
                await tareaBL.CrearAsync(tarea);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int idTarea, [FromBody] Tarea tarea)
        {
            if (tarea.IdTarea == idTarea)
            {
                await tareaBL.ModificarAsync(tarea);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idTarea}")]
        public async Task<ActionResult> Delete(int idTarea)
        {
            try
            {
                Tarea tarea = new Tarea();
                tarea.IdTarea = idTarea;
                await tareaBL.EliminarAsync(tarea);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Tarea>> Buscar([FromBody] object pTarea)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strTarea = JsonSerializer.Serialize(pTarea);
            Tarea tarea = JsonSerializer.Deserialize<Tarea>(strTarea, option);
            return await tareaBL.BuscarAsync(tarea);
        }
    }
}
