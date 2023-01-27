using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GestorDeProyectos.WebAPI.Auth;
using GestorDeProyectos.EntidadesDeNegocio;
using GestorDeProyectos.LogicaDeNegocios;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace GestorDeProyectos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UsuarioController : ControllerBase
    {
        private UsuarioBL usuarioBL = new UsuarioBL();

        private readonly IJwtAuthenticationService authService;

        public UsuarioController(IJwtAuthenticationService pAuthService)
        {
            authService = pAuthService;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await usuarioBL.ObtenerTodosAsync();
        }

        [HttpGet("{idUsuario}")]
        public async Task<Usuario> Get(int idUsuario)
        {
            Usuario usuario = new Usuario();
            usuario.IdUsuario = idUsuario;
            return await usuarioBL.ObtenerPorIdAsync(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                await usuarioBL.CrearAsync(usuario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int idUsuario, [FromBody] Usuario usuario)
        {
            if (usuario.IdUsuario == idUsuario)
            {
                await usuarioBL.ModificarAsync(usuario);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idUsuario}")]
        public async Task<ActionResult> Delete(int idUsuario)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = idUsuario;
                await usuarioBL.EliminarAsync(usuario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Usuario>> Buscar([FromBody] object pUsuario)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strUsuario = JsonSerializer.Serialize(pUsuario);
            Usuario usuario = JsonSerializer.Deserialize<Usuario>(strUsuario, option);
            return await usuarioBL.BuscarAsync(usuario);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] object pUsuario)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strUsuario = JsonSerializer.Serialize(pUsuario);
            Usuario usuario = JsonSerializer.Deserialize<Usuario>(strUsuario, option);
            Usuario usuario_auth = await usuarioBL.LoginAsync(usuario);
            if (usuario_auth != null && usuario_auth.IdUsuario > 0 && usuario.Login == usuario_auth.Login)
            {
                var token = authService.Authenticate(usuario_auth);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("CambiarPassword")]
        public async Task<ActionResult> CambiarPassword([FromBody] object pUsuario)
        {
            try
            {
                var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                string strUsuario = JsonSerializer.Serialize(pUsuario);
                Usuario usuario = JsonSerializer.Deserialize<Usuario>(strUsuario, option);
                await usuarioBL.CambiarPasswordAsync(usuario, usuario.ConfirmPassword_aux);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
