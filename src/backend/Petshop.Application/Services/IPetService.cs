using Petshop.Application.DTOs;
using Petshop.Application.Common;

namespace Petshop.Application.Services
{
    public interface IPetService
    {
        Task<Result<PetDto>> CriarPetAsync(CriarPetDto criarPetDto);
        Task<Result<IEnumerable<PetDto>>> ObterPorDono(Guid id);
        Task<Result<bool>> DeletarPetAsync(Guid id);
    }
}