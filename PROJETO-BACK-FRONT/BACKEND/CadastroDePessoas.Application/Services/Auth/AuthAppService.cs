using CadastroDePessoas.Application.Dtos.Usuarios;
using CadastroDePessoas.Application.Interfaces.Auth;
using CadastroDePessoas.Domain.Exceptions;
using CadastroDePessoas.Domain.Interfaces.Repositories;
using CadastroDePessoas.Domain.Interfaces.Security;
using CadastroDePessoas.Domain.Interfaces.Services.Auth;

namespace CadastroDePessoas.Application.Services.Auth
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IAuthDomainService? _authDomainService;
        private readonly ITokenService? _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public AuthAppService(IAuthDomainService? authDomainService, ITokenService? tokenService, IUnitOfWork unitOfWork)
        {
            _authDomainService = authDomainService;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public LoginResponseDto Login(LoginRequestDto dto)
        {
            try
            {
                var accessToken = _authDomainService?.Authenticate(dto.Email, dto.Senha);
                return new LoginResponseDto
                {
                    AccessToken = accessToken
                };
            }
            catch (AccessDeniedException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public void Dispose()
        {
            _authDomainService?.Dispose();
        }
    }
}
