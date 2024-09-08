using Microsoft.AspNetCore.Mvc;
using PraPets.Dtos;
using PraPets.Models;
using PraPets.Service;

namespace PraPets.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;   
        }

        [HttpGet("listar-usuarios")]
        public IActionResult ListarTodos()
        {
            List<UsuarioDto> usuarios = _usuarioService.listarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("buscar-usuario-por-id/{id}")]
        public IActionResult BuscarUsuarioPorId(int id)
        {
            UsuarioDto usuario = _usuarioService.buscarUsuarioPorId(id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            _usuarioService.deletarUsuario(id);
            return Ok();
        }
    }
}
