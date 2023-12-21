using HogwartsStudentsCrud.Data.Enums;
using HogwartsStudentsCrud.Model;
using HogwartsStudentsCrud.Model.Entities;
using HogwartsTest.IntegrationTests;
using Microsoft.Extensions.DependencyInjection;

namespace HogwartsApiTest.IntegrationTests
{
    public class HogwartsMockData
    {
        public static async Task CreateStudents(HogwartsApiApplication application, bool create)
        {
            using(var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using(var hogwartsDbContext = provider.GetRequiredService<SQLContext>())
                {
                    await hogwartsDbContext.Database.EnsureCreatedAsync();

                    if (create)
                    {
                        await hogwartsDbContext.Students.AddAsync(new Student 
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
                        });

                        await hogwartsDbContext.Students.AddAsync(new Student
                        {
                            Name = "Hermione Jean Granger",
                            BirthDate = DateTime.Parse("1979-09-19"),
                            Gender = GenderEnum.Female,
                            BloodStatus = BloodStatusTypeEnum.MuggleBorns,
                            EnrollmentYear = "1991",
                            Nationality = "English",
                            Boggart = "Failure",
                            Patron = "Otter",
                            Wand = "10¾\", Vine, dragon heartstring",
                            House = HousesEnum.Gryffindor
                        });

                        await hogwartsDbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
