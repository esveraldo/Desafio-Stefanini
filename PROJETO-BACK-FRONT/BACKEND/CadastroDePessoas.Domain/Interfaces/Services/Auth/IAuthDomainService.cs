using CadastroDePessoas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDePessoas.Domain.Interfaces.Services.Auth
{
    public interface IAuthDomainService : IDisposable
    {
        Usuario Get(string email, string password);
        string Authenticate(string email, string password);
    }
}
