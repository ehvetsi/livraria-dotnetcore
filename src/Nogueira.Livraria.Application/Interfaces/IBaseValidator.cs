using Nogueira.Livraria.Application.Dto;

namespace Nogueira.Livraria.Application.Interfaces
{
    public interface IBaseValidator<T> where T : BaseDto
    {
        bool Validate(T dto);
    }
}