using Petshop.Domain.Enums;
namespace Petshop.Application.DTOs
{
    public class ConsultaDto
    {
        public Guid Id { get; set; }     
        public Guid PetId { get; set; }   
        public DateTime Data { get; set; }
        public StatusConsulta Status { get; set; }
        public string Descricao { get; set; } = null!;
    }
}