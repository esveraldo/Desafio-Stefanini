using CadastroDePessoas.Domain.Core;
using CadastroDePessoas.Domain.Entities;

namespace CadastroDePessoas.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, Guid>
    {
    }
}
