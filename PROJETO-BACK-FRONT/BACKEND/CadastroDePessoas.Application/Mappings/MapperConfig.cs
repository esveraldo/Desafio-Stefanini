using AutoMapper;
using CadastroDePessoas.Application.Dtos.Pessoas;
using CadastroDePessoas.Application.Dtos.Usuarios;
using CadastroDePessoas.Domain.Entities;

namespace CadastroDePessoas.Application.Mappings
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Pessoa, GetPessoaDto>().ReverseMap();
            CreateMap<Usuario, GetUsuarioDto>().ReverseMap(); 
        }
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<InputPessoaDto, Pessoa>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
