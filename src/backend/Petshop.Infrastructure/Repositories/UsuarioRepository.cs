using Microsoft.EntityFrameworkCore;
using Petshop.Domain.Entities;
using Petshop.Domain.Interfaces;
using Petshop.Infrastructure.Data;
namespace Petshop.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly PetshopContext _context;

    public UsuarioRepository(PetshopContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> ObterPorIdAsync(Guid id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AdicionarAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
    }

    public async Task AtualizarAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
    }

    public async Task ExcluirAsync(Guid id)
    {
        var usuario = await ObterPorIdAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
        }
    }
}