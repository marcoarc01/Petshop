using Petshop.Domain.Interfaces;
using Petshop.Infrastructure.Repositories;
namespace Petshop.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly PetshopContext _context;

    public IPetRepository Pets { get; private set; }
    public IConsultaRepository Consultas { get; private set; }
    public IUsuarioRepository Usuarios { get; private set; }

    public UnitOfWork(PetshopContext context)
    {
        _context = context;
        Pets = new PetRepository(_context);
        Consultas = new ConsultaRepository(_context);
        Usuarios = new UsuarioRepository(_context);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}