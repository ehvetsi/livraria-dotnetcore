using System;

namespace Nogueira.Livraria.Application.Dto
{
    public class BookDto : BaseDto
    {
        public string AuthorName { get; set; }
        public string Name { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int Quantity { get; set; }
    }
}