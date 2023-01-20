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
    public class TipoRolBLTests
    {
        private static TipoRol tipoRolInicial = new TipoRol { IdTipoRol = 4, Nombre = "Ejemplo", Estatus = 1 };
        
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var tipoRol = new TipoRol();
            tipoRol.Nombre = "Ejemplo";
            tipoRol.Estatus = 1;
            int result = await new TipoRolBL().CrearAsync(tipoRol);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var tipoRol = new TipoRol();
            tipoRol.IdTipoRol = tipoRolInicial.IdTipoRol;
            tipoRol.Nombre = "Ejemplo Modificado";
            tipoRol.Estatus = 1;
            int result = await new TipoRolBL().ModificarAsync(tipoRol);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var tipoRol = new TipoRol();
            tipoRol.IdTipoRol = tipoRolInicial.IdTipoRol;
            var resultTipoRol = await new TipoRolBL().ObtenerPorIdAsync(tipoRol);
            Assert.AreEqual(tipoRol.IdTipoRol, resultTipoRol.IdTipoRol);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultTipoRol = await new TipoRolBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultTipoRol.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var tipoRol = new TipoRol();
            tipoRol.Nombre = "Ejemplo";
            tipoRol.Estatus = 1;
            var resultTipoRol = await new TipoRolBL().BuscarAsync(tipoRol);
            Assert.AreNotEqual(0, resultTipoRol.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var tipoRol = new TipoRol();
            tipoRol.IdTipoRol = tipoRolInicial.IdTipoRol;
            int result = await new TipoRolBL().EliminarAsync(tipoRol);
            Assert.IsTrue(result != 0);
        }
    }
}