using CadastroDePessoas.Domain.Entities;
using CadastroDePessoas.Domain.Exceptions;
using CadastroDePessoas.Domain.Interfaces.Repositories;
using CadastroDePessoas.Domain.Interfaces.Security;
using CadastroDePessoas.Domain.Interfaces.Services.Auth;
using CadastroDePessoas.Domain.Interfaces.Services.Pessoas;
using CadastroDePessoas.Domain.Interfaces.Services.Usuarios;

namespace CadastroDePessoas.Domain.Services.Auth
{
    public class AuthDomainService : IAuthDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioDomainService? _usuarioDomainService;
        private readonly ITokenService? _tokenService;
        private readonly IPessoaDomainService? _pessoasDomainService;

        public AuthDomainService(IUnitOfWork unitOfWork, IUsuarioDomainService? usuarioDomainService, ITokenService? tokenService)
        {
            _unitOfWork = unitOfWork;
            _usuarioDomainService = usuarioDomainService;
            _tokenService = tokenService;
        }

        public string Authenticate(string email, string password)
        {
            var usuario = Get(email, password);

            if (usuario == null)
                throw new AccessDeniedException();

            var usuarioAuth = new UsuarioAuth
            {
                Id = usuario.Id,
                Name = usuario.Nome,
                Email = usuario.Email,
                Role = usuario.Role,
                SignedAt = DateTime.Now,
            };

            return _tokenService?.CreateToken(usuarioAuth);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Usuario Get(string email, string senha)
        {
            return _unitOfWork?.usuarioRepository.Get(u => u.Email.Equals(email) && u.Senha.Equals(senha));
        }
    }
}
