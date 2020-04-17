using System;
using System.Threading.Tasks;

namespace ProjetoEscola.Repository.inteface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add<TEntity>(TEntity entity);

         void Update<TEntity>(TEntity entity);

         void Delete<TEntity>(TEntity entity);
         Task<bool> SaveChangesAsync();
    }
}