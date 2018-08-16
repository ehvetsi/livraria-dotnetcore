using Nogueira.Livraria.Application.Dto;
using System.Collections.Generic;

namespace Nogueira.Livraria.Application.Interfaces
{
    public interface IBookService
    {
        BookDto Add(BookDto dto);

        void Delete(int id);

        IList<BookDto> GetAll();

        BookDto GetById(int id);

        BookDto Update(int id, BookDto entity);
    }
}