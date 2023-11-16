using AutoMapper;
using Ramsay.Test.Data.Models.Dto;
using Ramsay.Test.Data.Models.Request;

namespace Ramsay.Test.Mapping
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<AddOrUpdateStudentReq, StudentDto>();
        }
    }
}