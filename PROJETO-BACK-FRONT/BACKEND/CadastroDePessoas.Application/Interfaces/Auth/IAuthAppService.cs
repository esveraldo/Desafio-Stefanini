using CadastroDePessoas.Application.Dtos.Usuarios;
using CadastroDePessoas.Domain.Entities;

namespace CadastroDePessoas.Application.Interfaces.Auth
{
    public interface IAuthAppService : IDisposable
    {
        LoginResponseDto Login(LoginRequestDto dto);
    }
}
