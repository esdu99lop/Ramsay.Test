namespace Ramsay.Test.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
