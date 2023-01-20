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
    public class ProyectoBLTests
    {
        private static Proyecto proyectoInicial = new Proyecto { IdProyecto = 3, Nombre = "Proyecto 3", Descripcion = "Descripcion 3", PeriodoDeDesarrollo = "3 meses", IdProducto = 1, Estatus = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var proyecto = new Proyecto();
            proyecto.Nombre = "Proyecto 3";
            proyecto.Descripcion = "Descripcion 3";
            proyecto.PeriodoDeDesarrollo = "3 meses";
            proyecto.IdProducto = 1;
            proyecto.Estatus = 1;
            int result = await new ProyectoBL().CrearAsync(proyecto);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var proyecto = new Proyecto();
            proyecto.IdProyecto = proyectoInicial.IdProyecto;
            proyecto.Nombre = "Ejemplo Modificado";
            proyecto.Descripcion = "Ejemplo";
            proyecto.PeriodoDeDesarrollo = "3 meses";
            proyecto.IdProducto = 1;
            proyecto.Estatus = 1;
            int result = await new ProyectoBL().ModificarAsync(proyecto);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var proyecto = new Proyecto();
            proyecto.IdProyecto = proyectoInicial.IdProyecto;
            var resultProyecto = await new ProyectoBL().ObtenerPorIdAsync(proyecto);
            Assert.AreEqual(proyecto.IdProyecto, resultProyecto.IdProyecto);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultProyecto = await new ProyectoBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultProyecto.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var proyecto = new Proyecto();
            proyecto.Nombre = "Ejemplo Modificado";
            proyecto.Descripcion = "Ejemplo";
            proyecto.PeriodoDeDesarrollo = "3 meses";
            proyecto.IdProducto = 1;
            proyecto.Estatus = 1;
            var resultProyecto = await new ProyectoBL().BuscarAsync(proyecto);
            Assert.AreNotEqual(0, resultProyecto.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var proyecto = new Proyecto();
            proyecto.IdProyecto = proyectoInicial.IdProyecto;
            int result = await new ProyectoBL().EliminarAsync(proyecto);
            Assert.IsTrue(result != 0);
        }
    }
}