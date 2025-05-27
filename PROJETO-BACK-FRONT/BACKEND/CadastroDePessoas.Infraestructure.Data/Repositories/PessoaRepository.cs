using CadastroDePessoas.Domain.Entities;
using CadastroDePessoas.Domain.Interfaces.Repositories;
using CadastroDePessoas.Infraestructure.Data.Contexts;

namespace CadastroDePessoas.Infraestructure.Data.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa, Guid>, IPessoaRepository
    {
        private readonly DataContext _dataContext;

        public PessoaRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
