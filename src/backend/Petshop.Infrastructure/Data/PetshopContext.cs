using Microsoft.EntityFrameworkCore;
using Petshop.Domain.Entities;

namespace Petshop.Infrastructure.Data;

public class PetshopContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    public PetshopContext(DbContextOptions<PetshopContext> options) : base(options)
    {
    }

}