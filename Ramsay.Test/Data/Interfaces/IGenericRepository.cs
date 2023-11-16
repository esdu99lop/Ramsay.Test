namespace Ramsay.Test.Data.Interfaces
{
    public interface IGenericRepository<in T>
    {
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
