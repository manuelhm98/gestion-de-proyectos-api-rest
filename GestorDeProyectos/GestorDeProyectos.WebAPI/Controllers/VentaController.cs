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

    public class VentaController : ControllerBase
    {
        private VentaBL ventaBL = new VentaBL();

        [HttpGet]
        public async Task<IEnumerable<Venta>> Get()
        {
            return await ventaBL.ObtenerTodosAsync();
        }

        [HttpGet("{idVenta}")]
        public async Task<Venta> Get(int idVenta)
        {
            Venta venta = new Venta();
            venta.IdVenta = idVenta;
            return await ventaBL.ObtenerPorIdAsync(venta);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Venta venta)
        {
            try
            {
                await ventaBL.CrearAsync(venta);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int idVenta, [FromBody] Venta venta)
        {
            if (venta.IdVenta == idVenta)
            {
                await ventaBL.ModificarAsync(venta);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idVenta}")]
        public async Task<ActionResult> Delete(int idVenta)
        {
            try
            {
                Venta venta = new Venta();
                venta.IdVenta = idVenta;
                await ventaBL.EliminarAsync(venta);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Venta>> Buscar([FromBody] object pVenta)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strVenta = JsonSerializer.Serialize(pVenta);
            Venta venta = JsonSerializer.Deserialize<Venta>(strVenta, option);
            return await ventaBL.BuscarAsync(venta);
        }
    }
}
