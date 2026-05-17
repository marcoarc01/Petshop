using Microsoft.AspNetCore.Mvc;
using Petshop.Application.Services;
using Petshop.Application.DTOs;

namespace Petshop.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarPetDto criarPetDto)
        {
            var resultado = await _petService.CriarPetAsync(criarPetDto);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.ErroMensagem);
            }
            return CreatedAtAction(nameof(Criar), resultado.Dados);
        }

        [HttpGet("dono/{DonoId}")]
        public async Task<IActionResult> GetPet(Guid DonoId)
        {
            var pet = await _petService.ObterPorDono(DonoId);
            if (!pet.Sucesso)
            {
                return NotFound(pet.ErroMensagem);
            }
            return Ok(pet.Dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(Guid id)
        {
            var resultado = await _petService.DeletarPetAsync(id);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.ErroMensagem);
            }
            return NoContent();
        }
    }
    
}