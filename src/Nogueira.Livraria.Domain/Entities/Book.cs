using System;

namespace Nogueira.Livraria.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string AuthorName { get; set; }
        public string Name { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int Quantity { get; set; }
    }
}