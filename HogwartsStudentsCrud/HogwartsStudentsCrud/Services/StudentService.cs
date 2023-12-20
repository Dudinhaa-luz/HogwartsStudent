using HogwartsStudentsCrud.Data.Commands;
using HogwartsStudentsCrud.Model.Entities;
using HogwartsStudentsCrud.Repositories;
using HogwartsStudentsCrud.Repositories.Interfaces;
using HogwartsStudentsCrud.Services.Interfaces;
using System.Net;

namespace HogwartsStudentsCrud.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<BaseResponseCommand<Student>> Add(Student student)
        {
            try
            {
                await _studentRepository.Update(student);

                return new BaseResponseCommand<Student>
                {
                    Code = HttpStatusCode.OK,
                    Message = $"Bruxo {student.Name} matriculado com sucesso. \r\n Seja bem vindo a Escola de Magia e Bruxaria de Hogwarts!",
                    IsSuccess = true,
                    Object = student
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseCommand<Student>
                {
                    Code = HttpStatusCode.BadGateway,
                    Message = $"Não conseguimos realizar seu cadastro, talvez você seja um trouxa! Exception: {ex.Message}",
                    IsSuccess = false,
                    Object = student
                };
            }
        }
        
    }
}

