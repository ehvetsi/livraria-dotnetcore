using AutoMapper;
using Nogueira.Livraria.Application.Dto;
using Nogueira.Livraria.Domain.Entities;

namespace Nogueira.Livraria.Application.AutoMapper
{
    public class DtoToDomainConfiguration : Profile
    {
        public DtoToDomainConfiguration()
        {
            CreateMap<Dto.BaseDto, Domain.Entities.BaseEntity>();

            CreateMap<BookDto, Book>();
        }
    }
}