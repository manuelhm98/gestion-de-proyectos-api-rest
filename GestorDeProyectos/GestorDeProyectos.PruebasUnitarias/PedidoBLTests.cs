using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorDeProyectos.LogicaDeNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestorDeProyectos.EntidadesDeNegocio;

namespace GestorDeProyectos.LogicaDeNegocios.Tests
{
    [TestClass()]
    public class PedidoBLTests
    {
        private static Pedido pedidoInicial = new Pedido { IdPedido = 2, FechaDePedido = Convert.ToDateTime("11/01/2023"), FechaDeEntrega = Convert.ToDateTime("11/02/2022"), MontoTotal = 25, IdCliente = 3, Estatus = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var pedido = new Pedido();
            pedido.FechaDePedido = Convert.ToDateTime("22/01/2023");
            pedido.FechaDeEntrega = Convert.ToDateTime("22/02/2023");
            pedido.MontoTotal = 80;
            pedido.IdCliente = 3;
            pedido.Estatus = 1;
            int result = await new PedidoBL().CrearAsync(pedido);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var pedido = new Pedido();
            pedido.IdPedido = pedidoInicial.IdPedido;
            pedido.FechaDePedido = Convert.ToDateTime("01/02/2023");
            pedido.FechaDeEntrega = Convert.ToDateTime("22/02/2023");
            pedido.MontoTotal = 90;
            pedido.IdCliente = 2;
            pedido.Estatus = 1;
            int result = await new PedidoBL().ModificarAsync(pedido);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var pedido = new Pedido();
            pedido.IdPedido = pedidoInicial.IdPedido;
            var resultPedido = await new PedidoBL().ObtenerPorIdAsync(pedido);
            Assert.AreEqual(pedido.IdPedido, resultPedido.IdPedido);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultPedido = await new PedidoBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultPedido.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var pedido = new Pedido();
            pedido.FechaDePedido = Convert.ToDateTime("01/02/2023");
            pedido.FechaDeEntrega = Convert.ToDateTime("22/02/2023");
            pedido.MontoTotal = 90;
            pedido.IdCliente = 2;
            pedido.Estatus = 1;
            var resultPedido = await new PedidoBL().BuscarAsync(pedido);
            Assert.AreNotEqual(0, resultPedido.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var pedido = new Pedido();
            pedido.IdPedido = pedidoInicial.IdPedido;
            int result = await new PedidoBL().EliminarAsync(pedido);
            Assert.IsTrue(result != 0);
        }
    }
}