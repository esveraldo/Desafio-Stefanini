using CadastroDePessoas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDePessoas.Domain.Interfaces.Services.Usuarios
{
    public interface IUsuarioDomainService
    {
        List<Usuario> TodosUsuarios();
    }
}
