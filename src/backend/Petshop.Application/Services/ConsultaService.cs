using Petshop.Domain.Interfaces;
using Petshop.Application.Common;
using Petshop.Application.DTOs;
using AutoMapper;
namespace Petshop.Application.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ConsultaService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Result<ConsultaDto>> CriarConsultaAsync(CriarConsultaDto criarConsultaDto)
        {
            var consulta = new Domain.Entities.Consulta(
                criarConsultaDto.PetId,
                criarConsultaDto.Data,
                criarConsultaDto.Descricao
            );
            await _uow.Consultas.AdicionarAsync(consulta);
            await _uow.CommitAsync();
            return Result<ConsultaDto>.Ok(_mapper.Map<ConsultaDto>(consulta));
        }
        public async Task<Result<ConsultaDto>> ObterPorIdAsync(Guid id)
        {
            var consulta = await _uow.Consultas.ObterPorIdAsync(id);
            if (consulta == null)
                return Result<ConsultaDto>.Falha("Consulta não encontrada.");

            return Result<ConsultaDto>.Ok(_mapper.Map<ConsultaDto>(consulta));
        }
        public async Task<Result<IEnumerable<ConsultaDto>>> ObterConsultasPorPetAsync(Guid petId)
        {
            var consultas = await _uow.Consultas.ObterPorPetAsync(petId);
            if (consultas == null || !consultas.Any())
                return Result<IEnumerable<ConsultaDto>>.Falha("Nenhuma consulta encontrada para este pet.");

            return Result<IEnumerable<ConsultaDto>>.Ok(_mapper.Map<List<ConsultaDto>>(consultas));
        }
        public async Task<Result<bool>> DeletarConsultaAsync(Guid id)
        {
            var consulta = await _uow.Consultas.ObterPorIdAsync(id);
            if (consulta == null)
                return Result<bool>.Falha("Consulta não encontrada.");

            await _uow.Consultas.ExcluirAsync(id);
            await _uow.CommitAsync();
            return Result<bool>.Ok(true);
        }
    }
}