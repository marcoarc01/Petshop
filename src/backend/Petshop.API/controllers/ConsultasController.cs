using Microsoft.AspNetCore.Mvc;
using Petshop.Application.Services;
using Petshop.Application.DTOs;

namespace Petshop.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultasController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarConsultaDto criarConsultaDto)
        {
            var resultado = await _consultaService.CriarConsultaAsync(criarConsultaDto);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.ErroMensagem);
            }
            return CreatedAtAction(nameof(Criar), resultado.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsulta(Guid id)
        {
            var consulta = await _consultaService.ObterPorIdAsync(id);
            if (!consulta.Sucesso)
            {
                return NotFound(consulta.ErroMensagem);
            }
            return Ok(consulta.Dados);
        }

        [HttpGet("pet/{petId}")]
        public async Task<IActionResult> GetConsultasPorPet(Guid petId)
        {
            var consultas = await _consultaService.ObterConsultasPorPetAsync(petId);
            if (!consultas.Sucesso)
            {
                return NotFound(consultas.ErroMensagem);
            }
            return Ok(consultas.Dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsulta(Guid id)
        {
            var resultado = await _consultaService.DeletarConsultaAsync(id);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.ErroMensagem);
            }
            return NoContent();
        }
    }
}