using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestorDeProyectos.AccesoADatos;
using GestorDeProyectos.EntidadesDeNegocio;

namespace GestorDeProyectos.LogicaDeNegocios
{
    public class EquipoBL
    {
        public async Task<int> CrearAsync(Equipo pEquipo)
        {
            return await EquipoDAL.CrearAsync(pEquipo);
        }

        public async Task<int> ModificarAsync(Equipo pEquipo)
        {
            return await EquipoDAL.ModificarAsync(pEquipo);
        }

        public async Task<int> EliminarAsync(Equipo pEquipo)
        {
            return await EquipoDAL.EliminarAsync(pEquipo);
        }

        public async Task<Equipo> ObtenerPorIdAsync(Equipo pEquipo)
        {
            return await EquipoDAL.ObtenerPorIdAsync(pEquipo);
        }
        public async Task<List<Equipo>> ObtenerTodosAsync()
        {
            return await EquipoDAL.ObtenerTodosAsync();
        }

        public async Task<List<Equipo>> BuscarAsync(Equipo pEquipo)
        {
            return await EquipoDAL.BuscarAsync(pEquipo);
        }
    }
}
