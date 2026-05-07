using Microsoft.EntityFrameworkCore;
using Petshop.Domain.Entities;
using Petshop.Domain.Interfaces;
using Petshop.Infrastructure.Data;
namespace Petshop.Infrastructure.Repositories;

public class PetRepository : IPetRepository
{
    private readonly PetshopContext _context;

    public PetRepository(PetshopContext context)
    {
        _context = context;
    }

    public async Task<Pet?> ObterPorIdAsync(Guid id)
    {
        return await _context.Pets.FindAsync(id);
    }

    public async Task<IEnumerable<Pet>> ObterPorDonoAsync(Guid donoId)
    {
        return await _context.Pets.Where(p => p.DonoId == donoId).ToListAsync();
    }

    public async Task AdicionarAsync(Pet pet)
    {
        await _context.Pets.AddAsync(pet);
    }

    public async Task AtualizarAsync(Pet pet)
    {
        _context.Pets.Update(pet);
    }

    public async Task ExcluirAsync(Guid id)
    {
        var pet = await ObterPorIdAsync(id);
        if (pet != null)
        {
            _context.Pets.Remove(pet);
        }
    }
    
}