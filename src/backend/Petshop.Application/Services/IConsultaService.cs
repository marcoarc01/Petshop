using Petshop.Application.DTOs;
using Petshop.Application.Common;

namespace Petshop.Application.Services
{
    public interface IConsultaService
    {
        Task<Result<ConsultaDto>> CriarConsultaAsync(CriarConsultaDto criarConsultaDto);
        Task<Result<ConsultaDto>> ObterPorIdAsync(Guid id);
        Task<Result<IEnumerable<ConsultaDto>>> ObterConsultasPorPetAsync(Guid petId);
        Task<Result<bool>> DeletarConsultaAsync(Guid id);
    }
}