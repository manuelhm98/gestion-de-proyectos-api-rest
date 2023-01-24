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
    public class UsuarioBLTests
    {
        private static Usuario usuarioInicial = new Usuario { IdUsuario = 6, IdRol = 1, Nombre = "Ejemplo", Apellido = "Ejemplo", Login = "Ejemplo1234", Password = "123456", Estatus = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = 2;
            usuario.Nombre = "Ejemplo";
            usuario.Apellido = "Ejemplo";
            usuario.Login = "Ejemplo1234";
            string passw = "123456";
            usuario.Password = passw;
            usuario.Estatus = 1;
            int result = await new UsuarioBL().CrearAsync(usuario);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdUsuario = usuarioInicial.IdUsuario;
            usuario.IdRol = 1;
            usuario.Nombre = "Ejemplo Modificado";
            usuario.Apellido = "Ejemplo Modificado";
            usuario.Login = "Ejemplo123";
            usuario.Estatus = 1;
            int result = await new UsuarioBL().ModificarAsync(usuario);
            Assert.AreNotEqual(0, result);
            usuarioInicial.Login = usuario.Login;
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdUsuario = usuarioInicial.IdUsuario;
            var resultUsuario = await new UsuarioBL().ObtenerPorIdAsync(usuario);
            Assert.AreEqual(usuario.IdUsuario, resultUsuario.IdUsuario);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultUsuario = await new UsuarioBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultUsuario.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = 1;
            usuario.Nombre = "Ejemplo";
            usuario.Apellido = "Ejemplo";
            usuario.Login = "Ejemplo123";
            usuario.Estatus = 1;
            var resultUsuario = await new UsuarioBL().BuscarAsync(usuario);
            Assert.AreNotEqual(0, resultUsuario.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirRolesAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = 1;
            usuario.Nombre = "E";
            usuario.Apellido = "E";
            usuario.Estatus = 1;
            usuario.Top_Aux = 10;
            var resultUsuario = await new UsuarioBL().BuscarIncluirRolesAsync(usuario);
            Assert.AreNotEqual(0, resultUsuario.Count);
            var ultimoUsuario = resultUsuario.FirstOrDefault();
            Assert.IsTrue(ultimoUsuario.IdRol != null && usuario.IdRol == ultimoUsuario.Rol.IdRol);
        }

        [TestMethod()]
        public async Task T7LoginAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Login = usuarioInicial.Login;
            usuario.Password = usuarioInicial.Password;
            var resultusuario = await new UsuarioBL().LoginAsync(usuario);
            Assert.AreEqual(usuario.Login, resultusuario.Login);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdUsuario = usuarioInicial.IdUsuario;
            int result = await new UsuarioBL().EliminarAsync(usuario);
            Assert.IsTrue(result != 0);
        }

    }
}
