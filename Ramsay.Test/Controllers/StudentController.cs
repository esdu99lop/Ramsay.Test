using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Test.Core.Interfaces;
using Ramsay.Test.Data.Interfaces;
using Ramsay.Test.Data.Models.Dto;
using Ramsay.Test.Data.Models.Request;
using System.Net;

namespace Ramsay.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _studentService = studentService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _studentService.GetStudents());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] AddOrUpdateStudentReq addOrUpdateStudentReq)
        {
            try
            {
                StudentDto studentDto = _mapper.Map<StudentDto>(addOrUpdateStudentReq);
                studentDto = await _studentService.CreateStudent(studentDto);
                await _unitOfWork.SaveChangesAsync();
                return Ok(studentDto);

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AddOrUpdateStudentReq addOrUpdateStudentReq)
        {
            try
            {
                StudentDto studentDto = await _studentService.UpdateStudent(id, _mapper.Map<StudentDto>(addOrUpdateStudentReq));
                await _unitOfWork.SaveChangesAsync();
                return Ok(studentDto);

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studentService.DeleteStudent(id);
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}