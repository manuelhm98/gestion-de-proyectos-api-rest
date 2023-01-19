using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestorDeProyectos.AccesoADatos;
using GestorDeProyectos.EntidadesDeNegocio;

namespace GestorDeProyectos.LogicaDeNegocios
{
    public class ClienteBL
    {
        public async Task<int> CrearAsync(Cliente pCliente)
        {
            return await ClienteDAL.CrearAsync(pCliente);
        }

        public async Task<int> ModificarAsync(Cliente pCliente)
        {
            return await ClienteDAL.ModificarAsync(pCliente);
        }

        public async Task<int> EliminarAsync(Cliente pCliente)
        {
            return await ClienteDAL.EliminarAsync(pCliente);
        }

        public async Task<Cliente> ObtenerPorIdAsync(Cliente pCliente)
        {
            return await ClienteDAL.ObtenerPorIdAsync(pCliente);
        }

        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            return await ClienteDAL.ObtenerTodosAsync();
        }

        public async Task<List<Cliente>> BuscarAsync(Cliente pCliente)
        {
            return await ClienteDAL.BuscarAsync(pCliente);
        }
    }
}
