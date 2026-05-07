using Microsoft.EntityFrameworkCore;
using Petshop.Domain.Entities;
using Petshop.Domain.Interfaces;
using Petshop.Infrastructure.Data;
namespace Petshop.Infrastructure.Repositories;


public class ConsultaRepository : IConsultaRepository
{
    private readonly PetshopContext _context;

    public ConsultaRepository(PetshopContext context)
    {
        _context = context;
    }

    public async Task<Consulta?> ObterPorIdAsync(Guid id)
    {
        return await _context.Consultas.FindAsync(id);
    }

    public async Task<IEnumerable<Consulta>> ObterPorPetAsync(Guid petId)
    {
        return await _context.Consultas.Where(c => c.PetId == petId).ToListAsync();
    }

    public async Task AdicionarAsync(Consulta consulta)
    {
        await _context.Consultas.AddAsync(consulta);
    }

    public async Task AtualizarAsync(Consulta consulta)
    {
        _context.Consultas.Update(consulta);
    }

    public async Task ExcluirAsync(Guid id)
    {
        var consulta = await ObterPorIdAsync(id);
        if (consulta != null)
        {
            _context.Consultas.Remove(consulta);
        }
    }
}