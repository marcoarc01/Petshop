namespace Petshop.Application.DTOs
{
    public class CriarConsultaDto
    {
        public Guid PetId { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; } = null!;
    }
}