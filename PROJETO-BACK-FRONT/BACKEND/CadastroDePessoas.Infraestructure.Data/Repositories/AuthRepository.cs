using CadastroDePessoas.Domain.Entities;
using CadastroDePessoas.Domain.Interfaces.Repositories;
using CadastroDePessoas.Infraestructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDePessoas.Infraestructure.Data.Repositories
{
    public class AuthRepository : BaseRepository<Usuario, Guid>, IAuthRepository
    {
        private readonly DataContext _dataContext;

        public AuthRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
