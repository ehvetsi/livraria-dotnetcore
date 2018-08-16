using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Nogueira.Livraria.Application.AutoMapper;
using Nogueira.Livraria.Application.Dto;
using Nogueira.Livraria.Application.Dto.Books;
using Nogueira.Livraria.Application.Interfaces;
using Nogueira.Livraria.Application.Services;
using Nogueira.Livraria.Data.Repositories;
using Nogueira.Livraria.Domain.Repositories;
using Nogueira.Livraria.Infra.Notifications;
using Nogueira.Livraria.Infra.Notifications.Interfaces;

namespace Nogueira.Livraria.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<INotificationHandler>(new NotificationHandler());
            services.AddSingleton<INotificationObserver>(new NotificationObserver());

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDtoConfiguration());
                cfg.AddProfile(new DtoToDomainConfiguration());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBaseValidator<BookDto>, BookValidator>();
        }
    }
}