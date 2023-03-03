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
    public class TipoRolBL
    {
        public async Task<int> CrearAsync(TipoRol pTipoRol)
        {
            return await TipoRolDAL.CrearAsync(pTipoRol);
        }

        public async Task<int> ModificarAsync(TipoRol pTipoRol)
        {
            return await TipoRolDAL.ModificarAsync(pTipoRol);
        }

        public async Task<int> EliminarAsync(TipoRol pTipoRol)
        {
            return await TipoRolDAL.EliminarAsync(pTipoRol);
        }

        public async Task<TipoRol> ObtenerPorIdAsync(TipoRol pTipoRol)
        {
            return await TipoRolDAL.ObtenerPorIdAsync(pTipoRol);
        }

        public async Task<ListPagTipoRol> ListPagTipoRol(int page = 1, int pageSize = 5, string tipoRol = "")
        {
            return await TipoRolDAL.ListPagTipoRol(page, pageSize, tipoRol);
        }

        public async Task<List<TipoRol>> ObtenerTodosAsync()
        {
            return await TipoRolDAL.ObtenerTodosAsync();
        }

        public async Task<List<TipoRol>> BuscarAsync(TipoRol pTipoRol)
        {
            return await TipoRolDAL.BuscarAsync(pTipoRol);
        }
    }
}
