using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TestServerInMemoryDbPOC.Data;
using TestServerPOC;
using TestServerPOC.Data;
using Xunit;

namespace XUnitTestProject1
{
    public class ApplicationUsersControllerGetApplicationUser
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _client;

        public ApplicationUsersControllerGetApplicationUser()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(builder);
            _context = server.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            _client = server.CreateClient();

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var user = new User
            {
                Name = "Andrew",
                Role = "Admin"
            };

            _context.User.Add(user);
            _context.SaveChanges();
        }

        [Fact]
        public async Task DoesReturnSuccess()
        {
            // Act
            var response = await _client.GetAsync($"/ApplicationUsers/GetData");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}