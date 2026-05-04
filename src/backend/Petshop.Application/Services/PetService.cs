using Petshop.Domain.Interfaces;
using Petshop.Application.Common;
using Petshop.Application.DTOs;
using AutoMapper;
namespace Petshop.Application.Services
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PetService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Result<PetDto>> CriarPetAsync(CriarPetDto criarPetDto)
        {
            var pet = new Petshop.Domain.Entities.Pet(
                criarPetDto.Nome,
                criarPetDto.Raca,
                criarPetDto.Tipo,
                criarPetDto.Peso,
                criarPetDto.DataNascimento,
                criarPetDto.DonoId
            );
            await _uow.Pets.AdicionarAsync(pet);
            await _uow.CommitAsync();
            return Result<PetDto>.Ok(_mapper.Map<PetDto>(pet));
        }

        public async Task<Result<IEnumerable<PetDto>>> ObterPorDono(Guid id)
        {
            var pets = await _uow.Pets.ObterPorDonoAsync(id);
            if (pets == null || !pets.Any())
                return Result<IEnumerable<PetDto>>.Falha("Nenhum pet encontrado para este dono.");

            return Result<IEnumerable<PetDto>>.Ok(_mapper.Map<List<PetDto>>(pets));
        }

        public async Task<Result<bool>> DeletarPetAsync(Guid id)
        {
            var pet = await _uow.Pets.ObterPorIdAsync(id);
            if (pet == null)
                return Result<bool>.Falha("Pet não encontrado.");

            await _uow.Pets.ExcluirAsync(id);
            await _uow.CommitAsync();
            return Result<bool>.Ok(true);
        }
    }
}