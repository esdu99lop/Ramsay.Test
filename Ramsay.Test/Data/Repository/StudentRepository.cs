using Microsoft.EntityFrameworkCore;
using Ramsay.Test.Data.Interfaces;
using Ramsay.Test.Data.Models;

namespace Ramsay.Test.Data.Repository
{
    public class StudentRepository : GenericRepository<StudentModel>, IStudentRepository
    {
        private readonly DataContext _dataContext;

        public StudentRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<StudentModel> FindById(int id)
        {
            StudentModel student = await _dataContext.Student
                .Where(s => s.Id.Equals(id))
                .SingleOrDefaultAsync();
            return student;
        }

        public async Task<StudentModel> FindByUserName(string userName)
        {
            StudentModel student = await _dataContext.Student
                .Where(s => s.Username.Equals(userName))
                .SingleOrDefaultAsync();
            return student;
        }

        public async Task<ICollection<StudentModel>> GetAll()
        {
            ICollection<StudentModel> students = await _databaseContext.Student
                .OrderByDescending(s => s.Id)
                .ToListAsync();
            return students;
        }

        public async Task DeleteById(int id)
        {
            StudentModel student = await _dataContext.Student
                .Where(s => s.Id.Equals(id))
                .SingleOrDefaultAsync();

            if (student != null)
                _dataContext.Student.Remove(student);
        }
    }
}
