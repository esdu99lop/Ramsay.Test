using Ramsay.Test.Data.Interfaces;

namespace Ramsay.Test.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DataContext _databaseContext;

        public GenericRepository(DataContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Add(T entity)
        {
            await _databaseContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _databaseContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _databaseContext.Set<T>().Remove(entity);
        }
    }
}
