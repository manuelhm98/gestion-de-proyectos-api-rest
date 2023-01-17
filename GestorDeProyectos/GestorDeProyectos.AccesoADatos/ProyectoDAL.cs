using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using GestorDeProyectos.EntidadesDeNegocio;

namespace GestorDeProyectos.AccesoADatos
{
    public class ProyectoDAL
    {
        public static async Task<int> CrearAsync(Proyecto pProyecto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pProyecto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Proyecto pProyecto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var proyecto = await bdContexto.Proyecto.FirstOrDefaultAsync(s => s.IdProyecto == pProyecto.IdProyecto);
                proyecto.Nombre = pProyecto.Nombre;
                proyecto.Descripcion = pProyecto.Descripcion;
                proyecto.PeriodoDeDesarrollo = pProyecto.PeriodoDeDesarrollo;
                proyecto.IdProducto = pProyecto.IdProducto;
                proyecto.Estatus = pProyecto.Estatus;
                bdContexto.Update(proyecto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Proyecto pProyecto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var proyecto = await bdContexto.Proyecto.FirstOrDefaultAsync(s => s.IdProyecto == pProyecto.IdProyecto);
                bdContexto.Proyecto.Remove(proyecto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Proyecto> ObtenerPorIdAsync(Proyecto pProyecto)
        {
            var proyecto = new Proyecto();
            using (var bdContexto = new BDContexto())
            {
                proyecto = await bdContexto.Proyecto.FirstOrDefaultAsync(s => s.IdProyecto == pProyecto.IdProyecto);
            }
            return proyecto;
        }

        public static async Task<List<Proyecto>> ObtenerTodosAsync()
        {
            var proyectos = new List<Proyecto>();
            using (var bdContexto = new BDContexto())
            {
                proyectos = await bdContexto.Proyecto.ToListAsync();
            }
            return proyectos;
        }
        
        internal static IQueryable<Proyecto> QuerySelect(IQueryable<Proyecto> pQuery, Proyecto pProyecto)
        {
            if (pProyecto.IdProyecto > 0)
                pQuery = pQuery.Where(s => s.IdProyecto == pProyecto.IdProyecto);
            if (!string.IsNullOrWhiteSpace(pProyecto.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pProyecto.Nombre));
            if (!string.IsNullOrWhiteSpace(pProyecto.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pProyecto.Descripcion));
            if (!string.IsNullOrWhiteSpace(pProyecto.PeriodoDeDesarrollo))
                pQuery = pQuery.Where(s => s.PeriodoDeDesarrollo.Contains(pProyecto.PeriodoDeDesarrollo));
            if (pProyecto.IdProducto > 0)
                pQuery = pQuery.Where(s => s.IdProducto == pProyecto.IdProducto);
            if (pProyecto.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pProyecto.Estatus);
            pQuery = pQuery.OrderByDescending(s => s.IdProducto).AsQueryable();
            if (pProyecto.Top_Aux > 0)
                pQuery = pQuery.Take(pProyecto.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Proyecto>> BuscarAsync(Proyecto pProyecto)
        {
            var proyectos = new List<Proyecto>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Proyecto.AsQueryable();
                select = QuerySelect(select, pProyecto);
                proyectos = await select.ToListAsync();
            }
            return proyectos;
        }
    }
}
