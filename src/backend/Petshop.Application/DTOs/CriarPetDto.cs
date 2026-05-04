using Petshop.Domain.Enums;
namespace Petshop.Application.DTOs
{
    public class CriarPetDto
    {
        public Guid DonoId { get; set; }
        public string Nome { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public string Raca { get; set; } = null!;
        public float Peso { get; set; }
        public TipoAnimal Tipo { get; set; }
    }
}