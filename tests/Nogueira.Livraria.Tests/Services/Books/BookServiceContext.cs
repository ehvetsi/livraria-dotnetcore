using AutoMapper;
using AutoMoqCore;
using Moq;
using Nogueira.Livraria.Application.AutoMapper;
using Nogueira.Livraria.Application.Dto;
using Nogueira.Livraria.Application.Interfaces;
using Nogueira.Livraria.Application.Services;
using Nogueira.Livraria.Domain.Repositories;

namespace Nogueira.Livraria.Tests.Services.Books
{
    public class BookServiceContext
    {
        public IMapper Mapper;
        private readonly AutoMoqer mocker;

        public BookServiceContext()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoToDomainConfiguration>();
                cfg.AddProfile<DomainToDtoConfiguration>();
            });
            Mapper = config.CreateMapper();

            mocker = new AutoMoqer();

            mocker.SetInstance(Mapper);
            BookRepository = mocker.GetMock<IBookRepository>();
            Validator = mocker.GetMock<IBaseValidator<BookDto>>();
            UnitOfWork = mocker.GetMock<IUnitOfWork>();
        }

        public Mock<IBookRepository> BookRepository { get; set; }
        public Mock<IUnitOfWork> UnitOfWork { get; set; }

        public Mock<IBaseValidator<BookDto>> Validator { get; set; }

        public BookService Create() => mocker.Create<BookService>();
    }
}