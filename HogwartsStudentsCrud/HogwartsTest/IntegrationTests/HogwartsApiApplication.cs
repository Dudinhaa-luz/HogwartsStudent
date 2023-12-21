using HogwartsStudentsCrud.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace HogwartsTest.IntegrationTests
{
    public class HogwartsApiApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<SQLContext>));
                services.AddDbContext<SQLContext>(options => options.UseInMemoryDatabase("HogwartsDatabase", root));
            });

            return base.CreateHost(builder);
        }
    }
}
