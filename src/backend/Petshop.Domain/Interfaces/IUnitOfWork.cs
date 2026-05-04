namespace  Petshop.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUsuarioRepository Usuarios { get; }
        IPetRepository Pets { get; }
        IConsultaRepository Consultas { get; }
        Task CommitAsync();
    }
}