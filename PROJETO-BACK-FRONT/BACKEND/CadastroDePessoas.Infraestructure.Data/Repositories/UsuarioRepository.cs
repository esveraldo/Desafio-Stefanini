using CadastroDePessoas.Domain.Core;
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
    public class UsuarioRepository : BaseRepository<Usuario, Guid>, IUsuarioRepository
    {
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
