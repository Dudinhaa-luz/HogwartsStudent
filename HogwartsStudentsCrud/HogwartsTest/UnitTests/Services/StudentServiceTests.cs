using Moq;
using HogwartsStudentsCrud.Repositories.Interfaces;
using HogwartsStudentsCrud.Services.Interfaces;
using HogwartsStudentsCrud.Services;
using HogwartsStudentsCrud.Model.Entities;
using HogwartsStudentsCrud.Data.Enums;

namespace HogwartsTest.UnitTests.Services
{
    public class StudentServiceTests
    {
        private Mock<IStudentRepository> _mockRepository;
        private IStudentService _studentService;

        public StudentServiceTests()
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
                Name = "Harry James Potter",
                BirthDate = DateTime.Parse("1980-07-31"),
                Gender = GenderEnum.Male,
                BloodStatus = BloodStatusTypeEnum.HalfBloods,
                EnrollmentYear = "1991",
                Nationality = "English",
                Boggart = "Dementor",
                Patron = "Stag",
                Wand = "11\", Holly, phoenix feather",
                House = HousesEnum.Gryffindor
            };

            //Act
            var result = _studentService.Add(student);

            //Assert
            Assert.True(result.Result.IsSuccess);
        }
    }
}