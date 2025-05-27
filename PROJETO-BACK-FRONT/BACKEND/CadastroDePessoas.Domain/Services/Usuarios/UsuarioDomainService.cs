using CadastroDePessoas.Domain.Entities;
using CadastroDePessoas.Domain.Interfaces.Repositories;
using CadastroDePessoas.Domain.Interfaces.Services.Usuarios;

namespace CadastroDePessoas.Domain.Services.Usuarios
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Usuario> TodosUsuarios()
        {
            return _unitOfWork.usuarioRepository.GetAll().ToList();
        }


    }
}

