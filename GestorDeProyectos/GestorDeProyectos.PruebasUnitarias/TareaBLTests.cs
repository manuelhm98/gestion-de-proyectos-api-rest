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
    public class TareaBLTests
    {
        private static Tarea tareaInicial = new Tarea { IdTarea = 4, Nombre = "Ejemplo", Estatus = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var tarea = new Tarea();
            tarea.Nombre = "Ejemplo";
            tarea.Descripcion = " Descripcion del Ejemplo";
            tarea.IdProyecto = 1;
            tarea.FechaDeInicio = Convert.ToDateTime("10/01/2023");
            tarea.FechaDeFinalizacion = Convert.ToDateTime("20/01/2023");
            tarea.Estatus = 1;
            int result = await new TareaBL().CrearAsync(tarea);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var tarea = new Tarea();
            tarea.IdTarea = tareaInicial.IdTarea;
            tarea.Nombre = "Ejemplo Mofificado";
            tarea.Descripcion = " Descripcion del Ejemplo";
            tarea.IdProyecto = 2;
            tarea.FechaDeInicio = Convert.ToDateTime("10/01/2023");
            tarea.FechaDeFinalizacion = Convert.ToDateTime("20/01/2023");
            tarea.Estatus = 1;
            int result = await new TareaBL().ModificarAsync(tarea);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var tarea = new Tarea();
            tarea.IdTarea = tareaInicial.IdTarea;
            var resultTarea = await new TareaBL().ObtenerPorIdAsync(tarea);
            Assert.AreEqual(tarea.IdTarea, resultTarea.IdTarea);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultTarea = await new TareaBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultTarea.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var tarea = new Tarea();
            tarea.Nombre = "Ejemplo Mofificado";
            tarea.Descripcion = " Descripcion del Ejemplo";
            tarea.IdProyecto = 2;
            tarea.FechaDeInicio = Convert.ToDateTime("10/01/2023");
            tarea.FechaDeFinalizacion = Convert.ToDateTime("20/01/2023");
            tarea.Estatus = 1;
            var resultTarea = await new TareaBL().BuscarAsync(tarea);
            Assert.AreNotEqual(0, resultTarea.Count);
        }


        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var tarea = new Tarea();
            tarea.IdTarea = tareaInicial.IdTarea;
            int result = await new TareaBL().EliminarAsync(tarea);
            Assert.IsTrue(result != 0);
        }
    }
}