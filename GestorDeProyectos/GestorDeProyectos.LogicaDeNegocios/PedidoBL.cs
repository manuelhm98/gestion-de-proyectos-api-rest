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
    public class PedidoBL
    {
        public async Task<int> CrearAsync(Pedido pPedido)
        {
            return await PedidoDAL.CrearAsync(pPedido);
        }

        public async Task<int> ModificarAsync(Pedido pPedido)
        {
            return await PedidoDAL.ModificarAsync(pPedido);
        }

        public async Task<int> EliminarAsync(Pedido pPedido)
        {
            return await PedidoDAL.EliminarAsync(pPedido);
        }

        public async Task<Pedido> ObtenerPorIdAsync(Pedido pPedido)
        {
            return await PedidoDAL.ObtenerPorIdAsync(pPedido);
        }

        public async Task<ListPagPedido> ListPagPedido(int page = 1, int pageSize = 5, string cliente = "")
        {
            return await PedidoDAL.ListPagPedido(page, pageSize, cliente);
        }

        public async Task<List<Pedido>> ObtenerTodosAsync()
        {
            return await PedidoDAL.ObtenerTodosAsync();
        }

        public async Task<List<Pedido>> BuscarAsync(Pedido pPedido)
        {
            return await PedidoDAL.BuscarAsync(pPedido);
        }
    }
}
