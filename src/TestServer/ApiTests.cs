using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class ApiServerShould : TestBase
    {
        [Theory]
        [InlineData("/api/hello")]
        [InlineData("/api/categories")]
        public async Task Get_HelloWorld(string url)
        {
            // Arrange
            var client = base.CreateServer();

            // Act
            var response = await client.CreateClient()
									   .GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("Hello World!", await response.Content.ReadAsStringAsync());
        }
    }
}