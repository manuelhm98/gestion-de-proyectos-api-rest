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
    public class PedidoDAL
    {
        public static async Task<int> CrearAsync(Pedido pPedido)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pPedido);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Pedido pPedido)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var pedido = await bdContexto.Pedido.FirstOrDefaultAsync(s => s.IdPedido == pPedido.IdPedido);
                pedido.FechaDePedido = pPedido.FechaDePedido;
                pedido.FechaDeEntrega = pPedido.FechaDeEntrega;
                pedido.MontoTotal = pPedido.MontoTotal;
                pedido.IdCliente = pPedido.IdCliente;
                pedido.Estatus = pPedido.Estatus;
                bdContexto.Update(pedido);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Pedido pPedido)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var pedido = await bdContexto.Pedido.FirstOrDefaultAsync(s => s.IdPedido == pPedido.IdPedido);
                bdContexto.Pedido.Remove(pedido);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Pedido> ObtenerPorIdAsync(Pedido pPedido)
        {
            var pedido = new Pedido();
            using (var bdContexto = new BDContexto())
            {
                pedido = await bdContexto.Pedido.FirstOrDefaultAsync(s => s.IdPedido == pPedido.IdPedido);
            }
            return pedido;
        }

        public static async Task<ListPagPedido> ListPagPedido(int page = 1, int pageSize = 5, string cliente = "")
        {

            var model = new ListPagPedido();
            using (var bdContexto = new BDContexto())
            {
                var pedidos = (from Pedido in bdContexto.Pedido.Include(c => c.Cliente)
                                 where Pedido.Estatus == 1 && Pedido.Cliente.Nombre.Contains(cliente)
                                 select Pedido).OrderByDescending(x => x.IdPedido).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                int totalRegistros = (from Pedido in bdContexto.Pedido
                                      where Pedido.Estatus == 1
                                      select Pedido).Count();

                model.Pedidos = pedidos;
                model.paginaActual = page;
                model.TotalRegistros = (int)Math.Ceiling((double)totalRegistros / pageSize);
                model.RegistroPorPagina = pageSize;
            }
            return model;
        }

        public static async Task<List<Pedido>> ObtenerTodosAsync()
        {
            var pedidos = new List<Pedido>();
            using (var bdContexto = new BDContexto())
            {
                pedidos = await bdContexto.Pedido.ToListAsync();
            }
            return pedidos;
        }

        internal static IQueryable<Pedido> QuerySelect(IQueryable<Pedido> pQuery, Pedido pPedido)
        {
            if (pPedido.IdPedido > 0)
                pQuery = pQuery.Where(s => s.IdPedido == pPedido.IdPedido);
            if (pPedido.MontoTotal > 0)
                pQuery = pQuery.Where(s => s.MontoTotal == pPedido.MontoTotal);
            if (pPedido.IdCliente > 0)
                pQuery = pQuery.Where(s => s.IdCliente == pPedido.IdCliente);
            if (pPedido.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pPedido.Estatus);
            pQuery = pQuery.OrderByDescending(s => s.IdPedido).AsQueryable();
            if (pPedido.Top_Aux > 0)
                pQuery = pQuery.Take(pPedido.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Pedido>> BuscarAsync(Pedido pPedido)
        {
            var pedidos = new List<Pedido>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Pedido.AsQueryable();
                select = QuerySelect(select, pPedido);
                pedidos = await select.ToListAsync();
            }
            return pedidos;
        }
    }
}
