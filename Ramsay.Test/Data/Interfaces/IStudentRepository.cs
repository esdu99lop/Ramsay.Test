using Ramsay.Test.Data.Models;

namespace Ramsay.Test.Data.Interfaces
{
    public interface IStudentRepository : IGenericRepository<StudentModel>
    {
        public Task<StudentModel> FindById(int id);
        public Task<StudentModel> FindByUserName(string userName);
        public Task<ICollection<StudentModel>> GetAll();
        public Task DeleteById(int id);
    }
}