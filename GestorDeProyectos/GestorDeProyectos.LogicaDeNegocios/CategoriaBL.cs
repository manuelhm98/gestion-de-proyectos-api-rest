using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestorDeProyectos.AccesoADatos;
using GestorDeProyectos.EntidadesDeNegocio;
using GestorDeProyectos.EntidadesDeNegocio.Paginación;

namespace GestorDeProyectos.LogicaDeNegocios
{
    public class CategoriaBL
    {
        public async Task<int> CrearAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.CrearAsync(pCategoria);
        }

        public async Task<int> ModificarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.ModificarAsync(pCategoria);
        }

        public async Task<int> EliminarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.EliminarAsync(pCategoria);
        }

        public async Task<Categoria> ObtenerPorIdAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.ObtenerPorIdAsync(pCategoria);
        }

        public async Task<ListPagCategoria> ListPagCategoria(int page = 1, int pageSize = 5, string categoria = "")
        {
            return await CategoriaDAL.ListPagCategoria(page, pageSize, categoria);
        }

        public async Task<List<Categoria>> ObtenerTodosAsync()
        {
            return await CategoriaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Categoria>> BuscarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.BuscarAsync(pCategoria);
        }
    }
}
