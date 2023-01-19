using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestorDeProyectos.AccesoADatos;
using GestorDeProyectos.EntidadesDeNegocio;

namespace GestorDeProyectos.LogicaDeNegocios
{
    public class ProyectoBL
    {
        public async Task<int> CrearAsync(Proyecto pProyecto)
        {
            return await ProyectoDAL.CrearAsync(pProyecto);
        }

        public async Task<int> ModificarAsync(Proyecto pProyecto)
        {
            return await ProyectoDAL.ModificarAsync(pProyecto);
        }

        public async Task<int> EliminarAsync(Proyecto pProyecto)
        {
            return await ProyectoDAL.EliminarAsync(pProyecto);
        }

        public async Task<Proyecto> ObtenerPorIdAsync(Proyecto pProyecto)
        {
            return await ProyectoDAL.ObtenerPorIdAsync(pProyecto);
        }

        public async Task<List<Proyecto>> ObtenerTodosAsync()
        {
            return await ProyectoDAL.ObtenerTodosAsync();
        }

        public async Task<List<Proyecto>> BuscarAsync(Proyecto pProyecto)
        {
            return await ProyectoDAL.BuscarAsync(pProyecto);
        }
    }
}
