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
    public class EquipoDAL
    {
        public static async Task<int> CrearAsync(Equipo pEquipo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pEquipo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Equipo pEquipo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var equipo = await bdContexto.Equipo.FirstOrDefaultAsync(s => s.IdEquipo == pEquipo.IdEquipo);
                equipo.Nombre = pEquipo.Nombre;
                equipo.IdUsuario = pEquipo.IdUsuario;
                equipo.Estatus = pEquipo.Estatus;
                bdContexto.Update(equipo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Equipo pEquipo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var equipo = await bdContexto.Equipo.FirstOrDefaultAsync(s => s.IdEquipo == pEquipo.IdEquipo);
                bdContexto.Equipo.Remove(equipo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Equipo> ObtenerPorIdAsync(Equipo pEquipo)
        {
            var equipo = new Equipo();
            using (var bdContexto = new BDContexto())
            {
                equipo = await bdContexto.Equipo.FirstOrDefaultAsync(s => s.IdEquipo == pEquipo.IdEquipo);
            }
            return equipo;
        }

        public static async Task<ListPagEquipo> ListPagEquipo(int page = 1, int pageSize = 5, string equipo = "", string usuario = "")
        {

            var model = new ListPagEquipo();
            using (var bdContexto = new BDContexto())
            {
                var equipos = (from Equipo in bdContexto.Equipo.Include(c => c.Usuario)
                                 where Equipo.Estatus == 1 && Equipo.Nombre.Contains(equipo) && Equipo.Usuario.Nombre.Contains(usuario)
                                 select Equipo).OrderByDescending(x => x.IdEquipo).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                int totalRegistros = (from Equipo in bdContexto.Equipo
                                      where Equipo.Estatus == 1
                                      select Equipo).Count();

                model.Equipos = equipos;
                model.paginaActual = page;
                model.TotalRegistros = (int)Math.Ceiling((double)totalRegistros / pageSize);
                model.RegistroPorPagina = pageSize;
            }
            return model;
        }

        public static async Task<List<Equipo>> ObtenerTodosAsync()
        {
            var equipos = new List<Equipo>();
            using (var bdContexto = new BDContexto())
            {
                equipos = await bdContexto.Equipo.ToListAsync();
            }
            return equipos;
        }

        internal static IQueryable<Equipo> QuerySelect(IQueryable<Equipo> pQuery, Equipo pEquipo)
        {
            if (pEquipo.IdEquipo > 0)
                pQuery = pQuery.Where(s => s.IdEquipo == pEquipo.IdEquipo);
            if (!string.IsNullOrWhiteSpace(pEquipo.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pEquipo.Nombre));
            if (pEquipo.IdUsuario > 0)
                pQuery = pQuery.Where(s => s.IdUsuario == pEquipo.IdUsuario);
            if (pEquipo.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pEquipo.Estatus);
            pQuery = pQuery.OrderByDescending(s => s.IdEquipo).AsQueryable();
            if (pEquipo.Top_Aux > 0)
                pQuery = pQuery.Take(pEquipo.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Equipo>> BuscarAsync(Equipo pEquipo)
        {
            var equipos = new List<Equipo>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Equipo.AsQueryable();
                select = QuerySelect(select, pEquipo);
                equipos = await select.ToListAsync();
            }
            return equipos;

        }
    }
}
