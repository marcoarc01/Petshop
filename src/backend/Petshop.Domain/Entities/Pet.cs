using Petshop.Domain.Enums;

namespace Petshop.Domain.Entities
{
    public class Pet
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; } = null!;
        public string Raca { get; private set; } = null!;
        public TipoAnimal Tipo { get; private set; }
        public float Peso { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Guid DonoId { get; private set; }

        private Pet() { }

        public Pet(string nome, string raca, TipoAnimal tipo, float peso, DateTime dataNascimento, Guid donoId)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Raca = raca;
            Tipo = tipo;
            Peso = peso;
            DataNascimento = dataNascimento;
            DonoId = donoId;
        }
    }
}