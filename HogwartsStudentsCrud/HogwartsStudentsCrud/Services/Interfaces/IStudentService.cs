using HogwartsStudentsCrud.Data.Commands;
using HogwartsStudentsCrud.Model.Entities;

namespace HogwartsStudentsCrud.Services.Interfaces
{
    public interface IStudentService
    {
        Task<BaseResponseCommand> Add(Student student);
        Task<BaseResponseCommand> GetAll();
    }
}
