using System;

namespace Nogueira.Livraria.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}