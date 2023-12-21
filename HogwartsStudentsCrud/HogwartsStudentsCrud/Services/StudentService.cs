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

        public async Task<BaseResponseCommand> Add(Student student)
        {
            try
            {
                await _studentRepository.Update(student);

                return new ResponseCommand<Student>
                {
                    Code = HttpStatusCode.OK,
                    Message = $"Bruxo {student.Name} matriculado com sucesso. \r\n Seja bem vindo a Escola de Magia e Bruxaria de Hogwarts!",
                    IsSuccess = true,
                    Object = student
                };
            }
            catch (Exception ex)
            {
                return ResponseMessages.ExceptionResponse(ex);
            }
        }

        public async Task<BaseResponseCommand> GetAll()
        {
            try
            {
                var students = await _studentRepository.GetAll();

                if(students.Count == 0)
                {
                    return new ResponseCommand()
                    {
                        Code = HttpStatusCode.NotFound,
                        Message = $"Nenhum bruxo matriculado!",
                        IsSuccess = false
                    };
                }

                return new ResponseCommand<List<Student>>()
                {
                    Code = HttpStatusCode.OK,
                    Message = $"Bruxos encontrados",
                    IsSuccess = true,
                    Object = students
                };
            }
            catch (Exception ex)
            {
                return ResponseMessages.ExceptionResponse(ex);
            }
        }
    }
}

