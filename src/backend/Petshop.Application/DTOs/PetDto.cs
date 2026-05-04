using Petshop.Domain.Enums;
namespace Petshop.Application.DTOs
{
    public class PetDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public int Idade { get; set; }
        public string Raca { get; set; } = null!;
        public float Peso { get; set; }
        public TipoAnimal Tipo { get; set; }
    }
}