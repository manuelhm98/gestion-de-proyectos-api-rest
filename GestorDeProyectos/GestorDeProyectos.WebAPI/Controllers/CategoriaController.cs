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
using GestorDeProyectos.AccesoADatos;

namespace GestorDeProyectos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CategoriaController : ControllerBase
    {
        private CategoriaBL categoriaBL = new CategoriaBL();

        private readonly BDContexto contexto;

        public CategoriaController(BDContexto context)
        {
            contexto = context;
        }

        [HttpGet]
        public async Task<ActionResult<PaginadorGenerico<Categoria>>> Get(string buscar = "", string orden = "IdCategoria", string tipo_orden = "ASC", int pagina = 1, int registros_por_pagina = 10)
        {
            List<Categoria> Categorias;
            PaginadorGenerico<Categoria> PaginadorCategorias;

            Categorias = contexto.Categoria.ToList();

            if (!string.IsNullOrEmpty(buscar))
            {
                foreach (var item in buscar.Split(new char[] { ' ' },
                         StringSplitOptions.RemoveEmptyEntries))
                {
                    Categorias = Categorias.Where(x => x.Nombre.Contains(item)).ToList();
                }
            }

            switch (orden)
            {
                case "IdCategoria":
                    if (tipo_orden.ToLower() == "desc")
                        Categorias = Categorias.OrderByDescending(x => x.IdCategoria).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        Categorias = Categorias.OrderBy(x => x.IdCategoria).ToList();
                    break;

                case "Nombre":
                    if (tipo_orden.ToLower() == "desc")
                        Categorias = Categorias.OrderByDescending(x => x.Nombre).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        Categorias = Categorias.OrderBy(x => x.Nombre).ToList();
                    break;

                case "Estatus":
                    if (tipo_orden.ToLower() == "desc")
                        Categorias = Categorias.OrderByDescending(x => x.Estatus).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        Categorias = Categorias.OrderBy(x => x.Estatus).ToList();
                    break;

                default:
                    if (tipo_orden.ToLower() == "desc")
                        Categorias = Categorias.OrderByDescending(x => x.IdCategoria).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        Categorias = Categorias.OrderBy(x => x.IdCategoria).ToList();
                    break;
            }

            int TotalRegistros = 0;
            int TotalPaginas = 0;

            TotalRegistros = Categorias.Count();

            Categorias = Categorias.Skip((pagina - 1) * registros_por_pagina)
                                             .Take(registros_por_pagina)
                                             .ToList();

            TotalPaginas = (int)Math.Ceiling((double)TotalRegistros / registros_por_pagina);

            PaginadorCategorias = new PaginadorGenerico<Categoria>()
            {
                RegistrosPorPagina = registros_por_pagina,
                TotalRegistros = TotalRegistros,
                TotalPaginas = TotalPaginas,
                PaginaActual = pagina,
                BusquedaActual = buscar,
                OrdenActual = orden,
                TipoOrdenActual = tipo_orden,
                Resultado = Categorias
            };

            return PaginadorCategorias;
        
        }

        [HttpGet("{idCategoria}")]
        public async Task<Categoria> Get(int idCategoria)
        {
            Categoria categoria = new Categoria();
            categoria.IdCategoria = idCategoria;
            return await categoriaBL.ObtenerPorIdAsync(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categoria categoria)
        {
            try
            {
                await categoriaBL.CrearAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int idCategoria, [FromBody] Categoria categoria)
        {
            if (categoria.IdCategoria == idCategoria)
            {
                await categoriaBL.ModificarAsync(categoria);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idCategoria}")]
        public async Task<ActionResult> Delete(int idCategoria)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.IdCategoria = idCategoria;
                await categoriaBL.EliminarAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Categoria>> Buscar([FromBody] object pCategoria)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCategoria = JsonSerializer.Serialize(pCategoria);
            Categoria categoria = JsonSerializer.Deserialize<Categoria>(strCategoria, option);
            return await categoriaBL.BuscarAsync(categoria);
        }
    }
}
