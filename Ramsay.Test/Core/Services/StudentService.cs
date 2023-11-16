using Ramsay.Test.Core.Interfaces;
using Ramsay.Test.Data.Interfaces;
using Ramsay.Test.Data.Models;
using Ramsay.Test.Data.Models.Dto;
using System.Net;

namespace Ramsay.Test.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ICollection<StudentModel>> GetStudents()
        {
            return await _studentRepository.GetAll();
        }

        public async Task<StudentModel> GetStudent(int id)
        {
            StudentModel student = await _studentRepository.FindById(id);
            if (student is null)
                throw new Exception("Unregistered Student");

            return student;
        }

        public async Task<StudentDto> CreateStudent(StudentDto studentDto)
        {
            StudentModel newStudent = new StudentModel()
            {
                Username = studentDto.Username,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Age = studentDto.Age,
                Career = studentDto.Career
            };
            await _studentRepository.Add(newStudent);
            return studentDto;
        }

        public async Task<StudentDto> UpdateStudent(int id, StudentDto studentDto)
        {
            StudentModel student = await GetStudent(id);

            student.Username = studentDto.Username;
            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;
            student.Age = studentDto.Age;
            student.Career = studentDto.Career;
            _studentRepository.Update(student);
            return studentDto;
        }

        public async Task DeleteStudent(int id)
        {
            await _studentRepository.DeleteById(id);
        }
    }
}