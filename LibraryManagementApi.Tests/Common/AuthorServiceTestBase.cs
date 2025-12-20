using LibraryManagementApi.Interfaces.IRepositories;
using LibraryManagementApi.Interfaces.IServices;
using LibraryManagementApi.Repositories;
using LibraryManagementApi.Services;

namespace LibraryManagementApi.Tests.Common
{
    [TestClass]
    public abstract class AuthorServiceTestBase
    {
        protected IAuthorService _service;
        protected IAuthorRepository _repository;

        [TestInitialize]
        public void BaseSetup()
        {
            _repository = new AuthorRepository();
            _service = new AuthorService(_repository);
        }
    }
}
