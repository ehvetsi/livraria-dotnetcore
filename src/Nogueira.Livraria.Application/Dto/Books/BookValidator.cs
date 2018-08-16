using FluentValidation;
using Nogueira.Livraria.Domain.Repositories;
using Nogueira.Livraria.Infra.Notifications.Interfaces;
using System;

namespace Nogueira.Livraria.Application.Dto.Books
{
    public class BookValidator : BaseValidator<BookDto>
    {
        private readonly IBookRepository repository;

        public BookValidator(INotificationHandler notificationHandler,
                             IBookRepository repository) : base(notificationHandler)
        {
            this.repository = repository;
        }

        public override void ValidateCreate()
        {
            ValidateCrud();
        }

        public override void ValidateDelete()
        {
            ValidateGet();
        }

        public override void ValidateGet()
        {
            RuleFor(c => c)
                .Must(c => ValidateGetById(c))
                .WithMessage(string.Format(Resources.Messages.EntityNotFound, "Livro"));
        }

        public override void ValidateList()
        {
        }

        public override void ValidateUpdate()
        {
            ValidateGet();
            When(c => ValidateGetById(c), () =>
              {
                  ValidateCrud();
              });
        }

        private void ValidateCrud()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage(string.Format(Resources.Messages.RequiredField, "Nome"))
                .MaximumLength(50)
                .WithMessage(string.Format(Resources.Messages.MaxLength, "Nome", 50));

            RuleFor(c => c.AuthorName)
                .MaximumLength(50)
                .WithMessage(string.Format(Resources.Messages.MaxLength, "Nome do Autor", 50));

            RuleFor(c => c.PublicationDate)
                .LessThan(DateTime.Now.Date)
                .WithMessage(string.Format(Resources.Messages.LessThan, "Data de publicação", DateTime.Now.ToShortDateString()));
        }

        private bool ValidateGetById(BookDto dto)
        {
            return repository.GetById(dto.Id) != null;
        }
    }
}