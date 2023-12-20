using Moq;
using HogwartsStudentsCrud.Repositories.Interfaces;
using HogwartsStudentsCrud.Services.Interfaces;
using HogwartsStudentsCrud.Services;
using HogwartsStudentsCrud.Model.Entities;
using HogwartsStudentsCrud.Data.Enums;

namespace HogwartsTest
{
    public class StudentTests
    {
        private Mock<IStudentRepository> _mockRepository;
        private IStudentService _studentService;

        public StudentTests()
        {
            _mockRepository = new Mock<IStudentRepository>();
            _studentService = new StudentService(_mockRepository.Object);
        }

        [Fact]
        public void Add_ReturnsSuccess()
        {
            //Arrange
            var student = new Student()
            {
                Name = "Test",
                BirthDate = DateTime.Now,
                BloodStatus = BloodStatusTypeEnum.HalfBloods,
                Bogeyman = "",
                EnrollmentYear = DateTime.Now,
                Gender = 0,
                House = 0,
                Nationality = "",
                Patron = "",
                Wand = ""
            };

            //Act
            var result = _studentService.Add(student);

            //Assert
            Assert.True(result.Result.IsSuccess);
        }
    }
}