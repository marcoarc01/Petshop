using Petshop.Domain.Interfaces;
using Petshop.Application.Common;
using Petshop.Application.DTOs;
using AutoMapper;
namespace Petshop.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UsuarioService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Result<UsuarioDto>> CriarUsuarioAsync(CriarUsuarioDto criarUsuarioDto)
        {
            var usuario = _mapper.Map<Domain.Entities.Usuario>(criarUsuarioDto);
            await _uow.Usuarios.AdicionarAsync(usuario);
            await _uow.CommitAsync();
            return Result<UsuarioDto>.Ok(_mapper.Map<UsuarioDto>(usuario));
        }

        public async Task<Result<UsuarioDto>> ObterPorIdAsync(Guid id)
        {
            var usuario = await _uow.Usuarios.ObterPorIdAsync(id);
            if (usuario == null)
                return Result<UsuarioDto>.Falha("Usuário não encontrado.");

            return Result<UsuarioDto>.Ok(_mapper.Map<UsuarioDto>(usuario));
        }

        public async Task<Result<UsuarioDto>> ObterPorEmailAsync(string email)
        {
            var usuario = await _uow.Usuarios.ObterPorEmailAsync(email);
            if (usuario == null)
                return Result<UsuarioDto>.Falha("Usuário não encontrado.");

            return Result<UsuarioDto>.Ok(_mapper.Map<UsuarioDto>(usuario));
        }
        
        public async Task<Result<bool>> DeletarUsuarioAsync(Guid id)
        {
            var usuario = await _uow.Usuarios.ObterPorIdAsync(id);
            if (usuario == null)
                return Result<bool>.Falha("Usuário não encontrado.");

            await _uow.Usuarios.ExcluirAsync(id);
            await _uow.CommitAsync();
            return Result<bool>.Ok(true);
        }
    }
}