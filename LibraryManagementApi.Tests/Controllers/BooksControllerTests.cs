using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace LibraryManagementApi.Tests.Controllers
{
    [TestClass]
    public class BooksControllerTests
    {
        private readonly HttpClient _httpClient;

        public BooksControllerTests()
        {
            var factory = new WebApplicationFactory<Program>();
            _httpClient = factory.CreateClient();
        }
        [TestMethod]
        public async Task GetBooks_ReturnOk()
        {
            //Act 
            var response = await _httpClient.GetAsync("/api/books");

            //Assert 
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetBooks_ReturnBookList()
        {
            //Act 
            var response = await _httpClient.GetAsync("/api/books");

            //Assert 
            response.EnsureSuccessStatusCode();

            var context = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrWhiteSpace(context));
        }
    }
}
