using HogwartsStudentsCrud.Model.Entities;

namespace HogwartsStudentsCrud.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task Update(Student student);
        Task Remove(Student student);
        Task<Student> GetById(Guid id);
        Task<List<Student>> GetAll();
    }
}
