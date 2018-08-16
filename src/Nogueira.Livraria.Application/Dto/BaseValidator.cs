using FluentValidation;
using Nogueira.Livraria.Application.Interfaces;
using Nogueira.Livraria.Infra.Enums;
using Nogueira.Livraria.Infra.Notifications.Interfaces;
using System.Linq;

namespace Nogueira.Livraria.Application.Dto
{
    public abstract class BaseValidator<T> : AbstractValidator<T>, IBaseValidator<T> where T : BaseDto
    {
        private readonly INotificationHandler notificationHandler;

        public BaseValidator(INotificationHandler notificationHandler)
        {
            this.notificationHandler = notificationHandler;
            When(x => x.IsCreate, () => ValidateCreate());
            When(x => x.IsUpdate, () => ValidateUpdate());
            When(x => x.IsList, () => ValidateList());
            When(x => x.IsDelete, () => ValidateDelete());
            When(x => x.IsGet, () => ValidateGet());
        }

        bool IBaseValidator<T>.Validate(T dto)
        {
            var result = base.Validate(dto as T);
            result.Errors.ToList()
                .ForEach(c =>
                {
                    notificationHandler.Notify(NotificationType.Error, c.ErrorMessage);
                    dto.IsValid = false;
                });
            dto.IsValid = result.IsValid;
            return result.IsValid;
        }

        public abstract void ValidateCreate();

        public abstract void ValidateDelete();

        public abstract void ValidateGet();

        public abstract void ValidateList();

        public abstract void ValidateUpdate();
    }
}