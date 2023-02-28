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

    public class ProductoController : ControllerBase
    {
        private ProductoBL productoBL = new ProductoBL();

        [HttpGet("paginated")]
        public async Task<ListPagProducto> ListPagProducto(int page = 1, int pageSize = 5, string producto ="", string categoria = "")
        {
            return await productoBL.ListPagProducto(page, pageSize, producto, categoria);
        }

        [HttpGet]
        public async Task<IEnumerable<Producto>> Get()
        {
            return await productoBL.ObtenerTodosAsync();
        }

        [HttpGet("{idProducto}")]
        public async Task<Producto> Get(int idProducto)
        {
            Producto producto = new Producto();
            producto.IdProducto = idProducto;
            return await productoBL.ObtenerPorIdAsync(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Producto producto)
        {
            try
            {
                await productoBL.CrearAsync(producto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int idProducto, [FromBody] Producto producto)
        {
            if (producto.IdProducto == idProducto)
            {
                await productoBL.ModificarAsync(producto);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idProducto}")]
        public async Task<ActionResult> Delete(int idProducto)
        {
            try
            {
                Producto producto = new Producto();
                producto.IdProducto = idProducto;
                await productoBL.EliminarAsync(producto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Producto>> Buscar([FromBody] object pProducto)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strProducto = JsonSerializer.Serialize(pProducto);
            Producto producto = JsonSerializer.Deserialize<Producto>(strProducto, option);
            return await productoBL.BuscarAsync(producto);
        }
    }
}
