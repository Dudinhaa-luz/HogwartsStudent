using HogwartsStudentsCrud.Data.Commands;
using HogwartsStudentsCrud.Model.Entities;
using HogwartsTest.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsApiTest.IntegrationTests.Tests
{
    public class ApiStudentIntegrationTests
    {
        [Fact]
        public async Task Get_Returns_All_Students()
        {
            await using var application = new HogwartsApiApplication();

            await HogwartsMockData.CreateStudents(application, true);
            var url = "api/Hogwarts/Student/GetAll";
            var client = application.CreateClient();

            var result = await client.GetAsync(url);
            var students = await client.GetFromJsonAsync<ResponseCommand<List<Student>>>("api/Hogwarts/Student/GetAll");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(students);
            Assert.True(students.Object.Count == 2);
        }
    }
}
