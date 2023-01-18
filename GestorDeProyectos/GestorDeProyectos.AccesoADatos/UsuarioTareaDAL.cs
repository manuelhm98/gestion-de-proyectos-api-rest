using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using GestorDeProyectos.EntidadesDeNegocio;

namespace GestorDeProyectos.AccesoADatos
{
    public class UsuarioTareaDAL
    {
        public static async Task<int> CrearAsync(UsuarioTarea pUsuarioTarea)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pUsuarioTarea);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(UsuarioTarea pUsuarioTarea)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var usuarioTarea = await bdContexto.UsuarioTarea.FirstOrDefaultAsync(s => s.IdUsuarioTarea == pUsuarioTarea.IdUsuarioTarea);
                usuarioTarea.IdUsuario = pUsuarioTarea.IdUsuario;
                usuarioTarea.IdTarea = pUsuarioTarea.IdTarea;
                bdContexto.Update(usuarioTarea);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(UsuarioTarea pUsuarioTarea)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var usuarioTarea = await bdContexto.UsuarioTarea.FirstOrDefaultAsync(s => s.IdUsuarioTarea == pUsuarioTarea.IdUsuarioTarea);
                bdContexto.UsuarioTarea.Remove(usuarioTarea);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<UsuarioTarea> ObtenerPorIdAsync(UsuarioTarea pUsuarioTarea)
        {
            var usuarioTarea = new UsuarioTarea();
            using (var bdContexto = new BDContexto())
            {
                usuarioTarea = await bdContexto.UsuarioTarea.FirstOrDefaultAsync(s => s.IdUsuarioTarea == pUsuarioTarea.IdUsuarioTarea);
            }
            return usuarioTarea;
        }

        public static async Task<List<UsuarioTarea>> ObtenerTodosAsync()
        {
            var usuarioTareas = new List<UsuarioTarea>();
            using (var bdContexto = new BDContexto())
            {
                usuarioTareas = await bdContexto.UsuarioTarea.ToListAsync();
            }
            return usuarioTareas;
        }

        internal static IQueryable<UsuarioTarea> QuerySelect(IQueryable<UsuarioTarea> pQuery, UsuarioTarea pUsuarioTarea)
        {
            if (pUsuarioTarea.IdUsuarioTarea > 0)
                pQuery = pQuery.Where(s => s.IdUsuarioTarea == pUsuarioTarea.IdUsuarioTarea);
            if (pUsuarioTarea.IdUsuario > 0)
                pQuery = pQuery.Where(s => s.IdUsuario == pUsuarioTarea.IdUsuario);
            if (pUsuarioTarea.IdTarea > 0)
                pQuery = pQuery.Where(s => s.IdTarea == pUsuarioTarea.IdTarea);
            pQuery = pQuery.OrderByDescending(s => s.IdUsuarioTarea).AsQueryable();
            if (pUsuarioTarea.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pUsuarioTarea.Estatus);
            if (pUsuarioTarea.Top_Aux > 0)
                pQuery = pQuery.Take(pUsuarioTarea.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<UsuarioTarea>> BuscarAsync(UsuarioTarea pUsuarioTarea)
        {
            var usuarioTareas = new List<UsuarioTarea>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.UsuarioTarea.AsQueryable();
                select = QuerySelect(select, pUsuarioTarea);
                usuarioTareas = await select.ToListAsync();
            }
            return usuarioTareas;

        }
    }
}
