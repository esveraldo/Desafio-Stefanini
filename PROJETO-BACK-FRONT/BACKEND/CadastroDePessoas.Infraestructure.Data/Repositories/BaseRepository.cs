using CadastroDePessoas.Domain.Core;
using CadastroDePessoas.Infraestructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CadastroDePessoas.Infraestructure.Data.Repositories
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(TEntity entity)
        {
            _dataContext.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dataContext.Entry(entity).State = EntityState.Deleted;
        }

        public List<TEntity> GetAll()
        {
            return _dataContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(TKey id)
        {
            return _dataContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity? Get(Func<TEntity, bool> where)
        {
            return _dataContext?.Set<TEntity>().FirstOrDefault(where);
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}
