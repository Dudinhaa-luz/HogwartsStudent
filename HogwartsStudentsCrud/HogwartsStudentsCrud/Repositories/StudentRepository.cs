using HogwartsStudentsCrud.Model;
using HogwartsStudentsCrud.Model.Entities;
using HogwartsStudentsCrud.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HogwartsStudentsCrud.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SQLContext _context;

        public StudentRepository(SQLContext context)
        {
            _context = context;
        }

        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> GetById(Guid id)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
