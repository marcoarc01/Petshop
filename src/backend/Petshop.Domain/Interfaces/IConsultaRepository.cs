using Petshop.Domain.Entities;
namespace Petshop.Domain.Interfaces
{
    public interface IConsultaRepository
    {
        Task<Consulta?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Consulta>> ObterPorPetAsync(Guid petId);
        Task AdicionarAsync(Consulta consulta);
        Task AtualizarAsync(Consulta consulta);
        Task ExcluirAsync(Guid id);
    }
}