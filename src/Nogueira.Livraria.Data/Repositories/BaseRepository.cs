using Microsoft.EntityFrameworkCore;
using Nogueira.Livraria.Domain.Entities;
using Nogueira.Livraria.Domain.Repositories;
using System;
using System.Linq;

namespace Nogueira.Livraria.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly EfContext context;
        private readonly DbSet<TEntity> dbSet;

        public BaseRepository(EfContext context)
        {
            this.context = context;
            dbSet = this.context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
            else
            {
                throw new InvalidOperationException(Resources.Messages.EntityNotFound);
            }
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
    }
}