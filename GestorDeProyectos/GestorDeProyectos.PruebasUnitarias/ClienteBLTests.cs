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
    public class ClienteBLTests
    {
        private static Cliente clienteInicial = new Cliente { IdCliente = 1, Nombre = "Cliente Modificado", Direccion = "Direccion Modificada", Telefono = 44444444, CorreoElectronico = "correoelectronico1@gmail.com", Estatus = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Nombre = "Cliente 3";
            cliente.Direccion = "Direccion 3";
            cliente.Telefono = 33333333;
            cliente.CorreoElectronico = "correoelectronico3@gmail.com";
            cliente.Estatus = 1;
            int result = await new ClienteBL().CrearAsync(cliente);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var cliente = new Cliente();
            cliente.IdCliente = clienteInicial.IdCliente;
            cliente.Nombre = "Cliente Modificado";
            cliente.Direccion = "Direccion modificada";
            cliente.Telefono = 44444444;
            cliente.CorreoElectronico = "correoelectronico1@gmail.com";
            cliente.Estatus = 1;
            int result = await new ClienteBL().ModificarAsync(cliente);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var cliente = new Cliente();
            cliente.IdCliente = clienteInicial.IdCliente;
            var resultCliente = await new ClienteBL().ObtenerPorIdAsync(cliente);
            Assert.AreEqual(cliente.IdCliente, resultCliente.IdCliente);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultCliente = await new ClienteBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultCliente.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Nombre = "Cliente Modificado";
            cliente.Direccion = "Direccion modificada";
            cliente.Telefono = 44444444;
            cliente.CorreoElectronico = "correoelectronico1@gmail.com";
            cliente.Estatus = 1;
            var resultCliente = await new ClienteBL().BuscarAsync(cliente);
            Assert.AreNotEqual(0, resultCliente.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var cliente = new Cliente();
            cliente.IdCliente = clienteInicial.IdCliente;
            int result = await new ClienteBL().EliminarAsync(cliente);
            Assert.IsTrue(result != 0);
        }
    }
}