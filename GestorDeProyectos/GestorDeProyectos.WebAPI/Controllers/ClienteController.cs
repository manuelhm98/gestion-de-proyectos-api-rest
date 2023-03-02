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

    public class ClienteController : ControllerBase
    {
        private ClienteBL clienteBL = new ClienteBL();

        [HttpGet("paginated")]
        public async Task<ListPagCliente> ListPagCliente(int page = 1, int pageSize = 5, string cliente = "")
        {
            return await clienteBL.ListPagCliente(page, pageSize, cliente);
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await clienteBL.ObtenerTodosAsync();
        }

        [HttpGet("{idCliente}")]
        public async Task<Cliente> Get(int idCliente)
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = idCliente;
            return await clienteBL.ObtenerPorIdAsync(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                await clienteBL.CrearAsync(cliente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int idCliente, [FromBody] Cliente cliente)
        {
            if (cliente.IdCliente == idCliente)
            {
                await clienteBL.ModificarAsync(cliente);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idCliente}")]
        public async Task<ActionResult> Delete(int idCliente)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = idCliente;
                await clienteBL.EliminarAsync(cliente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Cliente>> Buscar([FromBody] object pCliente)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCliente = JsonSerializer.Serialize(pCliente);
            Cliente cliente = JsonSerializer.Deserialize<Cliente>(strCliente, option);
            return await clienteBL.BuscarAsync(cliente);
        }
    }
}
