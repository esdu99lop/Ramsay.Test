using Ramsay.Test.Data.Models;
using Ramsay.Test.Data.Models.Dto;

namespace Ramsay.Test.Core.Interfaces
{
    public interface IStudentService
    {
        Task<StudentModel> GetStudent(int id);
        Task<ICollection<StudentModel>> GetStudents();
        Task<StudentDto> CreateStudent(StudentDto studentDto);
        Task<StudentDto> UpdateStudent(int id, StudentDto studentDto);
        Task DeleteStudent(int id);
    }
}
