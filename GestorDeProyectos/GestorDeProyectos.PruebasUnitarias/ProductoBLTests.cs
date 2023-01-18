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
    public class ProductoBLTests
    {
        private static Producto productoInicial = new Producto { IdProducto = 3, Nombre = "Ejemplo", Descripcion = "Ejemplo", Precio = 1, CantidadDisponible = 1, IdCategoria = 1, Estatus = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var producto = new Producto();
            producto.Nombre = "Ejemplo";
            producto.Descripcion = "Ejemplo";
            producto.Precio = 1;
            producto.CantidadDisponible = 1;
            producto.IdCategoria = 1;
            producto.Estatus = 1;
            int result = await new ProductoBL().CrearAsync(producto);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var producto = new Producto();
            producto.IdProducto = productoInicial.IdProducto;
            producto.Nombre = "Ejemplo";
            producto.Descripcion = "Ejemplo Modificado";
            producto.Precio = 2;
            producto.CantidadDisponible = 2;
            producto.IdCategoria = 1;
            producto.Estatus = 1;
            int result = await new ProductoBL().ModificarAsync(producto);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var producto = new Producto();
            producto.IdProducto = productoInicial.IdProducto;
            var resultProducto = await new ProductoBL().ObtenerPorIdAsync(producto);
            Assert.AreEqual(producto.IdProducto, resultProducto.IdProducto);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultProducto = await new ProductoBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultProducto.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var producto = new Producto();
            producto.Nombre = "Ejemplo";
            producto.Descripcion = "Ejemplo Modificado";
            producto.Precio = 2;
            producto.CantidadDisponible = 2;
            producto.IdCategoria = 1;
            producto.Estatus = 1;
            var resultProducto = await new ProductoBL().BuscarAsync(producto);
            Assert.AreNotEqual(0, resultProducto.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var producto = new Producto();
            producto.IdProducto = productoInicial.IdProducto;
            int result = await new ProductoBL().EliminarAsync(producto);
            Assert.IsTrue(result != 0);
        }
    }
}