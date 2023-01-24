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

    public class PedidoController : ControllerBase
    {
        private PedidoBL pedidoBL = new PedidoBL();

        [HttpGet]
        public async Task<IEnumerable<Pedido>> Get()
        {
            return await pedidoBL.ObtenerTodosAsync();
        }

        [HttpGet("{idPedido}")]
        public async Task<Pedido> Get(int idPedido)
        {
            Pedido pedido = new Pedido();
            pedido.IdPedido = idPedido;
            return await pedidoBL.ObtenerPorIdAsync(pedido);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Pedido pedido)
        {
            try
            {
                await pedidoBL.CrearAsync(pedido);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int idPedido, [FromBody] Pedido pedido)
        {
            if (pedido.IdPedido == idPedido)
            {
                await pedidoBL.ModificarAsync(pedido);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idPedido}")]
        public async Task<ActionResult> Delete(int idPedido)
        {
            try
            {
                Pedido pedido = new Pedido();
                pedido.IdPedido = idPedido;
                await pedidoBL.EliminarAsync(pedido);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Pedido>> Buscar([FromBody] object pPedido)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strPedido = JsonSerializer.Serialize(pPedido);
            Pedido pedido = JsonSerializer.Deserialize<Pedido>(strPedido, option);
            return await pedidoBL.BuscarAsync(pedido);
        }
    }
}
