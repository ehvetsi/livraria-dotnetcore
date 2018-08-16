using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Nogueira.Livraria.Application.Dto;
using Nogueira.Livraria.Application.Interfaces;
using Nogueira.Livraria.Infra.Enums;
using Nogueira.Livraria.Infra.Notifications.Interfaces;
using System;
using System.Collections.Generic;

namespace Nogueira.Livraria.WebApi.Controllers
{
    /// <summary>
    /// Controller para cadastro de livros
    /// </summary>
    [Route("api/[controller]")]
    [EnableCors("vuejsApplication")]
    public class BooksController : BaseController
    {
        private readonly IBookService bookService;
        private readonly INotificationHandler handler;

        /// <summary>
        /// Construtor que inicializa o serviço de livros e classe de notificações
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="observer"></param>
        /// <param name="bookService"></param>
        public BooksController(INotificationHandler handler,
                               INotificationObserver observer,
                               IBookService bookService) : base(handler, observer)
        {
            this.handler = handler;
            this.bookService = bookService;
        }

        /// <summary>
        /// Remove um livro
        /// </summary>
        /// <param name="id">Id do livro</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                bookService.Delete(id);
            }
            catch (Exception)
            {
                //Logar exceção
                handler.Notify(NotificationType.Error, Resources.Messages.FailedOperation);
            }
        }

        /// <summary>
        /// Retorna a lista com todos os livros cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BookDto> Get()
        {
            try
            {
                return bookService.GetAll();
            }
            catch (Exception)
            {
                //Logar exceção
                handler.Notify(NotificationType.Error, Resources.Messages.FailedOperation);
            }
            return null;
        }

        /// <summary>
        /// Retorna um livro de acordo com o id específicado
        /// </summary>
        /// <param name="id">Id do livro</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public BookDto Get(int id)
        {
            try
            {
                return bookService.GetById(id);
            }
            catch (Exception)
            {
                //Logar exceção
                handler.Notify(NotificationType.Error, Resources.Messages.FailedOperation);
            }
            return null;
        }

        /// <summary>
        /// Cadastra um novo livro
        /// </summary>
        /// <param name="dto">Dto de Livro</param>
        /// <returns></returns>
        [HttpPost]
        public BookDto Post([FromBody]BookDto dto)
        {
            try
            {
                return bookService.Add(dto);
            }
            catch (Exception)
            {
                //Logar exceção
                handler.Notify(NotificationType.Error, Resources.Messages.FailedOperation);
            }
            return null;
        }

        /// <summary>
        /// Atualiza os dados de um livro
        /// </summary>
        /// <param name="id">Id do livro a ser atualizado</param>
        /// <param name="dto">Dto de livro</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public BookDto Put(int id, [FromBody]BookDto dto)
        {
            try
            {
                return bookService.Update(id, dto);
            }
            catch (Exception)
            {
                //Logar exceção
                handler.Notify(NotificationType.Error, Resources.Messages.FailedOperation);
            }
            return null;
        }
    }
}