using Moq;
using Nogueira.Livraria.Application.Dto;
using Nogueira.Livraria.Domain.Entities;
using Xunit;

namespace Nogueira.Livraria.Tests.Services.Books
{
    public class BookServiceTest
    {
        private readonly BookServiceContext context;

        public BookServiceTest()
        {
            context = new BookServiceContext();
            context.Validator
                .Setup(c => c.Validate(It.IsAny<BookDto>()))
                .Returns(true);
        }

        [Fact(DisplayName = "BookService - DeveChamarAddDoBookRepositoryAoExecutarAdd")]
        public void DeveChamarAddDoBookRepositoryAoExecutarSave()
        {
            //Arrange
            var service = context.Create();

            //Act
            service.Add(new BookDto()
            {
                Name = "",
                AuthorName = "Nome do Autor"
            });

            //Assert
            context.BookRepository.Verify(x => x.Add(It.IsAny<Book>()), Times.Once());
        }
    }
}