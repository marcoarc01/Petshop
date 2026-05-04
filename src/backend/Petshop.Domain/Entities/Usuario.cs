namespace Petshop.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Senha { get; private set; } = null!;
        private readonly List<Pet> _pets = new();
        public IReadOnlyCollection<Pet> Pets => _pets.AsReadOnly();


        private Usuario() { }

        public Usuario(string nome, string email, string senha)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}