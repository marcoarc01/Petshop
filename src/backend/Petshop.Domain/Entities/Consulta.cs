using Petshop.Domain.Enums;

namespace Petshop.Domain.Entities
{
    public class Consulta
    {
        public Guid Id { get; private set; }
        public Guid PetId { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; } = null!;
        public StatusConsulta Status { get; private set; }

        private Consulta() { }

        public Consulta(Guid petId, DateTime data, string descricao)
        {
            Id = Guid.NewGuid();
            PetId = petId;
            Data = data;
            Descricao = descricao;
            Status = StatusConsulta.Agendada;
        }
    }
}