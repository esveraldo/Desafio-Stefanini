using CadastroDePessoas.Domain.Entities;

namespace CadastroDePessoas.Domain.Interfaces.Security
{
    public interface ITokenService
    {
        string CreateToken(UsuarioAuth userAuth);
    }
}
