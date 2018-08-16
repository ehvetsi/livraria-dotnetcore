using AutoMapper;
using Nogueira.Livraria.Application.Dto;
using Nogueira.Livraria.Domain.Entities;

namespace Nogueira.Livraria.Application.AutoMapper
{
    public class DomainToDtoConfiguration : Profile
    {
        public DomainToDtoConfiguration()
        {
            CreateMap<Book, BookDto>();
        }
    }
}