using Microsoft.AspNetCore.Mvc;
using Petshop.Application.Services;
using Petshop.Application.DTOs;

namespace Petshop.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarUsuarioDto criarUsuarioDto)
        {
            var resultado = await _usuarioService.CriarUsuarioAsync(criarUsuarioDto);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.ErroMensagem);
            }
            return CreatedAtAction(nameof(Criar), resultado.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(Guid id)
        {
            var usuario = await _usuarioService.ObterPorIdAsync(id);
            if (!usuario.Sucesso)
            {
                return NotFound(usuario.ErroMensagem);
            }
            return Ok(usuario.Dados);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUsuarioPorEmail(string email)
        {
            var usuario = await _usuarioService.ObterPorEmailAsync(email);
            if (!usuario.Sucesso)
            {
                return NotFound(usuario.ErroMensagem);
            }
            return Ok(usuario.Dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            var resultado = await _usuarioService.DeletarUsuarioAsync(id);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.ErroMensagem);
            }
            return NoContent();
        }
    }
}