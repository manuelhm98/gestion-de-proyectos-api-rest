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
    public class VentaBLTests
    {
        private static Venta ventaInicial = new Venta { IdVenta = 2, FechaDeVenta = Convert.ToDateTime("01/02/2023"), MontoTotal = 50, IdProducto = 1, IdCliente = 3, Estatus = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var venta = new Venta();
            venta.FechaDeVenta = Convert.ToDateTime("22/01/2023");
            venta.MontoTotal = 50;
            venta.IdProducto = 2;
            venta.IdCliente = 3;
            venta.Estatus = 1;
            int result = await new VentaBL().CrearAsync(venta);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var venta = new Venta();
            venta.IdVenta = ventaInicial.IdVenta;
            venta.FechaDeVenta = Convert.ToDateTime("22/01/2023");
            venta.MontoTotal = 120;
            venta.IdProducto = 1;
            venta.IdCliente = 2;
            venta.Estatus = 1;
            int result = await new VentaBL().ModificarAsync(venta);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var venta = new Venta();
            venta.IdVenta = ventaInicial.IdVenta;
            var resultVenta = await new VentaBL().ObtenerPorIdAsync(venta);
            Assert.AreEqual(venta.IdVenta, resultVenta.IdVenta);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultVenta = await new VentaBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultVenta.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var venta = new Venta();
            venta.FechaDeVenta = Convert.ToDateTime("22/01/2023");
            venta.MontoTotal = 120;
            venta.IdProducto = 1;
            venta.IdCliente = 2;
            venta.Estatus = 1;
            var resultVenta = await new VentaBL().BuscarAsync(venta);
            Assert.AreNotEqual(0, resultVenta.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var venta = new Venta();
            venta.IdVenta = ventaInicial.IdVenta;
            int result = await new VentaBL().EliminarAsync(venta);
            Assert.IsTrue(result != 0);
        }
    }
}