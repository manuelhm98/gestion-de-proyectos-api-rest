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
    public class TareaDAL
    {
        public static async Task<int> CrearAsync(Tarea pTarea)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pTarea);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Tarea pTarea)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var tarea = await bdContexto.Tarea.FirstOrDefaultAsync(s => s.IdTarea == pTarea.IdTarea);
                tarea.Nombre = pTarea.Nombre;
                tarea.Descripcion = pTarea.Descripcion;
                tarea.IdProyecto = pTarea.IdProyecto;
                tarea.FechaDeInicio = pTarea.FechaDeInicio;
                tarea.FechaDeFinalizacion = pTarea.FechaDeFinalizacion;
                tarea.Estatus = pTarea.Estatus;
                bdContexto.Update(tarea);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Tarea pTarea)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var tarea = await bdContexto.Tarea.FirstOrDefaultAsync(s => s.IdTarea == pTarea.IdTarea);
                bdContexto.Tarea.Remove(tarea);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Tarea> ObtenerPorIdAsync(Tarea pTarea)
        {
            var tarea = new Tarea();
            using (var bdContexto = new BDContexto())
            {
                tarea = await bdContexto.Tarea.FirstOrDefaultAsync(s => s.IdTarea == pTarea.IdTarea);
            }
            return tarea;
        }

        public static async Task<ListPagTarea> ListPagTarea(int page = 1, int pageSize = 5, string tarea = "", string proyecto = "")
        {

            var model = new ListPagTarea();
            using (var bdContexto = new BDContexto())
            {
                var tareas = (from Tarea in bdContexto.Tarea.Include(c => c.Proyecto)
                                 where Tarea.Estatus == 1 && Tarea.Nombre.Contains(tarea) && Tarea.Proyecto.Nombre.Contains(proyecto)
                                 select Tarea).OrderByDescending(x => x.IdTarea).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                int totalRegistros = (from Tarea in bdContexto.Tarea
                                      where Tarea.Estatus == 1
                                      select Tarea).Count();

                model.Tareas = tareas;
                model.paginaActual = page;
                model.TotalRegistros = (int)Math.Ceiling((double)totalRegistros / pageSize);
                model.RegistroPorPagina = pageSize;
            }
            return model;
        }

        public static async Task<List<Tarea>> ObtenerTodosAsync()
        {
            var tareas = new List<Tarea>();
            using (var bdContexto = new BDContexto())
            {
                tareas = await bdContexto.Tarea.ToListAsync();
            }
            return tareas;
        }

        internal static IQueryable<Tarea> QuerySelect(IQueryable<Tarea> pQuery, Tarea pTarea)
        {
            if (pTarea.IdTarea > 0)
                pQuery = pQuery.Where(s => s.IdTarea == pTarea.IdTarea);
            if (!string.IsNullOrWhiteSpace(pTarea.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pTarea.Nombre));
            if (!string.IsNullOrWhiteSpace(pTarea.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pTarea.Descripcion));
            if (pTarea.IdProyecto > 0)
                pQuery = pQuery.Where(s => s.IdProyecto == pTarea.IdProyecto);
            if (pTarea.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pTarea.Estatus);
            pQuery = pQuery.OrderByDescending(s => s.IdTarea).AsQueryable();
            if (pTarea.Top_Aux > 0)
                pQuery = pQuery.Take(pTarea.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Tarea>> BuscarAsync(Tarea pTarea)
        {
            var tareas = new List<Tarea>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Tarea.AsQueryable();
                select = QuerySelect(select, pTarea);
                tareas = await select.ToListAsync();
            }
            return tareas;

        }
    }
}
