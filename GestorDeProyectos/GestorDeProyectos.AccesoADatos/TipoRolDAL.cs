using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using GestorDeProyectos.EntidadesDeNegocio;
using GestorDeProyectos.EntidadesDeNegocio.Paginación;

namespace GestorDeProyectos.AccesoADatos
{
    public class TipoRolDAL
    {
        public static async Task<int> CrearAsync(TipoRol pTipoRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pTipoRol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(TipoRol pTipoRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var tipoRol = await bdContexto.TipoRol.FirstOrDefaultAsync(s => s.IdTipoRol == pTipoRol.IdTipoRol);
                tipoRol.Nombre = pTipoRol.Nombre;
                tipoRol.Estatus = pTipoRol.Estatus;
                bdContexto.Update(tipoRol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(TipoRol pTipoRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var tipoRol = await bdContexto.TipoRol.FirstOrDefaultAsync(s => s.IdTipoRol == pTipoRol.IdTipoRol);
                bdContexto.TipoRol.Remove(tipoRol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<TipoRol> ObtenerPorIdAsync(TipoRol pTipoRol)
        {
            var tipoRol = new TipoRol();
            using (var bdContexto = new BDContexto())
            {
                tipoRol = await bdContexto.TipoRol.FirstOrDefaultAsync(s => s.IdTipoRol == pTipoRol.IdTipoRol);
            }
            return tipoRol;
        }

        public static async Task<ListPagTipoRol> ListPagTipoRol(int page = 1, int pageSize = 5, string tipoRol = "")
        {

            var model = new ListPagTipoRol();
            using (var bdContexto = new BDContexto())
            {
                var tipoRoles = (from TipoRol in bdContexto.TipoRol
                                 where TipoRol.Estatus == 1 && TipoRol.Nombre.Contains(tipoRol)
                                  select TipoRol).OrderByDescending(x => x.IdTipoRol).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                int totalRegistros = (from TipoRol in bdContexto.TipoRol
                                      where TipoRol.Estatus == 1
                                      select TipoRol).Count();

                model.TipoRoles = tipoRoles;
                model.paginaActual = page;
                model.TotalRegistros = (int)Math.Ceiling((double)totalRegistros / pageSize);
                model.RegistroPorPagina = pageSize;
            }
            return model;
        }

        public static async Task<List<TipoRol>> ObtenerTodosAsync()
        {
            var tipoRoles = new List<TipoRol>();
            using (var bdContexto = new BDContexto())
            {
                tipoRoles = await bdContexto.TipoRol.ToListAsync();
            }
            return tipoRoles;
        }

        internal static IQueryable<TipoRol> QuerySelect(IQueryable<TipoRol> pQuery, TipoRol pTipoRol)
        {
            if (pTipoRol.IdTipoRol > 0)
                pQuery = pQuery.Where(s => s.IdTipoRol == pTipoRol.IdTipoRol);
            if (!string.IsNullOrWhiteSpace(pTipoRol.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pTipoRol.Nombre));
            if (pTipoRol.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pTipoRol.Estatus);
            pQuery = pQuery.OrderByDescending(s => s.IdTipoRol).AsQueryable();
            if (pTipoRol.Top_Aux > 0)
                pQuery = pQuery.Take(pTipoRol.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<TipoRol>> BuscarAsync(TipoRol pTipoRol)
        {
            var tipoRoles = new List<TipoRol>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.TipoRol.AsQueryable();
                select = QuerySelect(select, pTipoRol);
                tipoRoles = await select.ToListAsync();
            }
            return tipoRoles;

        }
    }
}
