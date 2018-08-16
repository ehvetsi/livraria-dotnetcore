using Nogueira.Livraria.Domain.Entities;
using System;
using System.Linq;

namespace Nogueira.Livraria.Domain.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        void Add(TEntity entity);

        void Delete(int id);

        IQueryable<TEntity> GetAll();

        TEntity GetById(int id);

        int SaveChanges();

        void Update(TEntity entity);
    }
}