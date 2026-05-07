using AutoMapper;
using Petshop.Domain.Entities;
using Petshop.Application.DTOs;

namespace Petshop.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pet, PetDto>()
                .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => 
                    DateTime.Today.Year - src.DataNascimento.Year));
            
            CreateMap<Consulta, ConsultaDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}