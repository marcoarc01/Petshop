using Petshop.Application.DTOs;
using Petshop.Application.Common;

namespace Petshop.Application.Services
{
    public interface IUsuarioService
    {
        Task<Result<UsuarioDto>> CriarUsuarioAsync(CriarUsuarioDto criarUsuarioDto);
        Task<Result<UsuarioDto>> ObterPorIdAsync(Guid id);
        Task<Result<UsuarioDto>> ObterPorEmailAsync(string email);
        Task<Result<bool>> DeletarUsuarioAsync(Guid id);
    }
}