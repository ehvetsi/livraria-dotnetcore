using Nogueira.Livraria.Domain.Entities;
using Nogueira.Livraria.Domain.Repositories;

namespace Nogueira.Livraria.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(EfContext context) : base(context)
        {
        }
    }
}