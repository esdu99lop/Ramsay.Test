using Ramsay.Test.Data.Interfaces;

namespace Ramsay.Test.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext _dataContext { get; private set; }

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}