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
    public class UsuarioTareaBL
    {
        public async Task<int> CrearAsync(UsuarioTarea pUsuarioTarea)
        {
            return await UsuarioTareaDAL.CrearAsync(pUsuarioTarea);
        }

        public async Task<int> ModificarAsync(UsuarioTarea pUsuarioTarea)
        {
            return await UsuarioTareaDAL.ModificarAsync(pUsuarioTarea);
        }

        public async Task<int> EliminarAsync(UsuarioTarea pUsuarioTarea)
        {
            return await UsuarioTareaDAL.EliminarAsync(pUsuarioTarea);
        }

        public async Task<UsuarioTarea> ObtenerPorIdAsync(UsuarioTarea pUsuarioTarea)
        {
            return await UsuarioTareaDAL.ObtenerPorIdAsync(pUsuarioTarea);
        }

        public async Task<ListPagUsuarioTarea> ListPagUsuarioTarea(int page = 1, int pageSize = 5, string usuario = "", string tarea = "")
        {
            return await UsuarioTareaDAL.ListPagUsuarioTarea(page, pageSize, usuario, tarea);
        }

        public async Task<List<UsuarioTarea>> ObtenerTodosAsync()
        {
            return await UsuarioTareaDAL.ObtenerTodosAsync();
        }

        public async Task<List<UsuarioTarea>> BuscarAsync(UsuarioTarea pUsuarioTarea)
        {
            return await UsuarioTareaDAL.BuscarAsync(pUsuarioTarea);
        }
    }
}
