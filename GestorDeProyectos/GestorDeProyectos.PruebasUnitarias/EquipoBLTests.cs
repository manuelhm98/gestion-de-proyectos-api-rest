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
    public class EquipoBLTests
    {
        private static Equipo equipoInicial = new Equipo { IdEquipo = 4, Nombre = "Ejemplo", Estatus = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var equipo = new Equipo();
            equipo.Nombre = "Ejemplo";
            equipo.IdUsuario = 1;
            equipo.Estatus = 1;
            int result = await new EquipoBL().CrearAsync(equipo);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var equipo = new Equipo();
            equipo.IdEquipo = equipoInicial.IdEquipo;
            equipo.Nombre = "Ejemplo Modificado";
            equipo.IdUsuario = 1;
            equipo.Estatus = 1;
            int result = await new EquipoBL().ModificarAsync(equipo);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var equipo = new Equipo();
            equipo.IdEquipo = equipoInicial.IdEquipo;
            var resultEquipo = await new EquipoBL().ObtenerPorIdAsync(equipo);
            Assert.AreEqual(equipo.IdEquipo, resultEquipo.IdEquipo);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultEquipo = await new EquipoBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultEquipo.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var equipo = new Equipo();
            equipo.Nombre = "Ejemplo";
            equipo.IdUsuario = 1;
            equipo.Estatus = 1;
            var resultEquipo = await new EquipoBL().BuscarAsync(equipo);
            Assert.AreNotEqual(0, resultEquipo.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var equipo = new Equipo();
            equipo.IdEquipo = equipoInicial.IdEquipo;
            int result = await new EquipoBL().EliminarAsync(equipo);
            Assert.IsTrue(result != 0);
        }

    }
}