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
    public class UsuarioTareaBLTests
    {
        private static UsuarioTarea usuarioTareaInicial = new UsuarioTarea { IdUsuarioTarea = 4, Estatus = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var usuarioTarea = new UsuarioTarea();
            usuarioTarea.IdUsuario = 1;
            usuarioTarea.IdTarea = 1;
            usuarioTarea.Estatus = 1;
            int result = await new UsuarioTareaBL().CrearAsync(usuarioTarea);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var usuarioTarea = new UsuarioTarea();
            usuarioTarea.IdUsuarioTarea = usuarioTareaInicial.IdUsuarioTarea;
            usuarioTarea.IdUsuario = 2;
            usuarioTarea.IdTarea = 2;
            usuarioTarea.Estatus = 1;
            int result = await new UsuarioTareaBL().ModificarAsync(usuarioTarea);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var usuarioTarea = new UsuarioTarea();
            usuarioTarea.IdUsuarioTarea = usuarioTareaInicial.IdUsuarioTarea;
            var resultUsuarioTarea = await new UsuarioTareaBL().ObtenerPorIdAsync(usuarioTarea);
            Assert.AreEqual(usuarioTarea.IdUsuarioTarea, resultUsuarioTarea.IdUsuarioTarea);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultUsuarioTarea = await new UsuarioTareaBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultUsuarioTarea.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var usuarioTarea = new UsuarioTarea();
            usuarioTarea.IdUsuario = 2;
            usuarioTarea.IdTarea = 2;
            usuarioTarea.Estatus = 1;
            var resultUsuarioTarea = await new UsuarioTareaBL().BuscarAsync(usuarioTarea);
            Assert.AreNotEqual(0, resultUsuarioTarea.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var usuarioTarea = new UsuarioTarea();
            usuarioTarea.IdUsuarioTarea = usuarioTareaInicial.IdUsuarioTarea;
            int result = await new UsuarioTareaBL().EliminarAsync(usuarioTarea);
            Assert.IsTrue(result != 0);
        }

    }
}