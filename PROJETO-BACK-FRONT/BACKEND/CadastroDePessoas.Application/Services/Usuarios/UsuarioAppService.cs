using AutoMapper;
using CadastroDePessoas.Application.Dtos.Pessoas;
using CadastroDePessoas.Application.Dtos.Usuarios;
using CadastroDePessoas.Application.Interfaces.Pessoas;
using CadastroDePessoas.Application.Interfaces.Usuarios;
using CadastroDePessoas.Domain.Interfaces.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDePessoas.Application.Services.Usuarios
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioDomainService _usuarioDomainService;

        public UsuarioAppService(IMapper mapper, IUsuarioDomainService usuarioDomainService)
        {
            _mapper = mapper;
            _usuarioDomainService = usuarioDomainService;
        }
  
        public IEnumerable<GetUsuarioDto> GetAll()
        {
            return _mapper.Map<IEnumerable<GetUsuarioDto>>(_usuarioDomainService.TodosUsuarios());
        }

    }
}
