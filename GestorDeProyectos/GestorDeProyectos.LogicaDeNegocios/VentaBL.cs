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
    public class VentaBL
    {
        public async Task<int> CrearAsync(Venta pVenta)
        {
            return await VentaDAL.CrearAsync(pVenta);
        }

        public async Task<int> ModificarAsync(Venta pVenta)
        {
            return await VentaDAL.ModificarAsync(pVenta);
        }

        public async Task<int> EliminarAsync(Venta pVenta)
        {
            return await VentaDAL.EliminarAsync(pVenta);
        }

        public async Task<Venta> ObtenerPorIdAsync(Venta pVenta)
        {
            return await VentaDAL.ObtenerPorIdAsync(pVenta);
        }

        public async Task<ListPagVenta> ListPagVenta(int page = 1, int pageSize = 5, string producto = "", string cliente = "")
        {
            return await VentaDAL.ListPagVenta(page, pageSize, producto, cliente);
        }

        public async Task<List<Venta>> ObtenerTodosAsync()
        {
            return await VentaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Venta>> BuscarAsync(Venta pVenta)
        {
            return await VentaDAL.BuscarAsync(pVenta);
        }
    }
}
