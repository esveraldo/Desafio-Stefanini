using CadastroDePessoas.Application.Dtos.Usuarios;

namespace CadastroDePessoas.Application.Interfaces.Usuarios
{
    public interface IUsuarioAppService
    {
        IEnumerable<GetUsuarioDto> GetAll();
    }
}
