using Nogueira.Livraria.Domain.Repositories;

namespace Nogueira.Livraria.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfContext context;

        public UnitOfWork(EfContext context)
        {
            this.context = context;
        }

        public bool Commit()
        {
            return context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}