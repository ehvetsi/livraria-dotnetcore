using AutoMapper;
using AutoMapper.QueryableExtensions;
using Nogueira.Livraria.Application.Dto;
using Nogueira.Livraria.Application.Interfaces;
using Nogueira.Livraria.Domain.Entities;
using Nogueira.Livraria.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Nogueira.Livraria.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper mapper;
        private readonly IBookRepository repository;
        private readonly IUnitOfWork unitOfWork;

        private readonly IBaseValidator<BookDto> validator;

        public BookService(IBookRepository repository,
                           IMapper mapper,
                           IUnitOfWork unitOfWork,
                           IBaseValidator<BookDto> validator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.validator = validator;
        }

        public BookDto Add(BookDto dto)
        {
            dto.IsCreate = true;
            if (validator.Validate(dto))
            {
                var entity = mapper.Map<Book>(dto);
                repository.Add(entity);
                unitOfWork.Commit();
                dto.Id = entity.Id;
            }
            return dto;
        }

        public void Delete(int id)
        {
            if (validator.Validate(new BookDto() { Id = id, IsDelete = true }))
            {
                repository.Delete(id);
                unitOfWork.Commit();
            }
        }

        public IList<BookDto> GetAll()
        {
            //Em caso de filtros na listagem utilizar o validator de List
            return repository.GetAll().ProjectTo<BookDto>(mapper.ConfigurationProvider).ToList();
        }

        public BookDto GetById(int id)
        {
            var dto = new BookDto() { Id = id, IsGet = true };
            if (validator.Validate(dto))
            {
                var entity = repository.GetById(id);
                return mapper.Map<BookDto>(entity);
            }
            return dto;
        }

        public BookDto Update(int id, BookDto dto)
        {
            dto.IsUpdate = true;
            dto.Id = id;
            if (validator.Validate(dto))
            {
                var entity = repository.GetById(dto.Id);
                entity = mapper.Map(dto, entity);
                repository.Update(entity);
                unitOfWork.Commit();
            }
            return dto;
        }
    }
}