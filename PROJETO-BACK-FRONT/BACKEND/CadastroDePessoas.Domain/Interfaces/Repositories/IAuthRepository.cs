using CadastroDePessoas.Domain.Core;
using CadastroDePessoas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDePessoas.Domain.Interfaces.Repositories
{
    public interface IAuthRepository : IBaseRepository<Usuario, Guid>
    {
    }
}
