using Petshop.Domain.Entities;
namespace Petshop.Domain.Interfaces
{
    public interface IPetRepository
    {
        Task<Pet?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Pet>> ObterPorDonoAsync(Guid donoId);
        Task AdicionarAsync(Pet pet);
        Task AtualizarAsync(Pet pet);
        Task ExcluirAsync(Guid id);
    }
}