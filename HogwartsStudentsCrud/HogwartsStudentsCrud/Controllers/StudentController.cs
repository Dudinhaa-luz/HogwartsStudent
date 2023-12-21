using HogwartsStudentsCrud.Model.Entities;
using HogwartsStudentsCrud.Services;
using HogwartsStudentsCrud.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsStudentsCrud.Controllers
{
    [ApiController]
    [Route("api/Hogwarts/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(Student student)
        {
            if(student == null)
            {
                return BadRequest("Bruxo, informe seus dados! Caso contrário sua matrícula não será realizada! \r\n" +
                                  "Algumas coisas não podem simplesmente serem resolvidas com magia ou adivinhação!");
            }

            var response = await _studentService.Add(student);
            if(response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _studentService.GetAll();

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }
    }
}
