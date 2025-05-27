using CadastroDePessoas.Domain.Interfaces.Repositories;
using CadastroDePessoas.Infraestructure.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace CadastroDePessoas.Infraestructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IDbContextTransaction _dbContextTransaction;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = _dataContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContextTransaction.Commit();
        }

        public void Rollback()
        {
            _dbContextTransaction?.Rollback();
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public IPessoaRepository pessoaRepository => new PessoaRepository(_dataContext);
        public IUsuarioRepository usuarioRepository => new UsuarioRepository(_dataContext);
        public IAuthRepository authRepository => new AuthRepository(_dataContext);
        public void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}
