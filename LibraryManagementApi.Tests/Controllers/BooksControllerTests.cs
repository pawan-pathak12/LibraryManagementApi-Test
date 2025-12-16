using LibraryManagementApi.Data;
using LibraryManagementApi.Interfaces;
using LibraryManagementApi.Models;
using LibraryManagementApi.Tests.Fakes;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text;
using System.Text.Json;

namespace LibraryManagementApi.Tests.Controllers
{
    [TestClass]
    public class BooksControllerTests
    {
        private readonly HttpClient _httpClient;

        public BooksControllerTests()
        {
            var factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.AddDbContext<LibraryDbContext>(options =>
                            options.UseInMemoryDatabase("TestDb"));

                        var provider = services.BuildServiceProvider();
                        using var scope = provider.CreateScope();
                        var context = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();

                        context.Books.Add(new Book
                        {
                            Title = "Clean Code",
                            Author = "Robert C. Martin",
                            Price = 500
                        });

                        context.SaveChanges();
                    });
                });

            _httpClient = factory.CreateClient();
        }


        #region Get EndPoint testing 
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

        [TestMethod]
        public async Task GetBooks_WhenNoBooks_ReturnNoContent()
        {
            //Arrange 
            var factory = new WebApplicationFactory<Program>()
              .WithWebHostBuilder(builder =>
              {
                  builder.ConfigureServices(services =>
                  {
                      services.AddScoped<IBookService, EmptyBookService>();
                  });
              });

            var client = factory.CreateClient();

            //Act 
            var response = await client.GetAsync("/api/books");

            //Assert 
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

        }

        #endregion

        #region Product Post EndPoint test 

        [TestMethod]
        public async Task CreateBook_ValidBook_ReturnCreated()
        {
            //Arrange 
            var newBook = new Book
            {
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt",
                Price = 600
            };

            var content = new StringContent(
                JsonSerializer.Serialize(newBook),
                Encoding.UTF8,
                "application/json"
             );

            //Act 
            var response = await _httpClient.PostAsync("/api/books", content);

            //Assert 
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public async Task CreateBook_InvalidBook_ReturnsBadRequest()
        {
            //Arrange 
            var invalidBook = new Book
            {
                Title = "",
                Author = "",
                Price = 0
            };

            var content = new StringContent(
                JsonSerializer.Serialize(invalidBook),
                Encoding.UTF8,
                "application/json"
             );

            //Act 
            var response = await _httpClient.PostAsync("/api/books", content);

            //Assert 
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        #endregion
    }
}
