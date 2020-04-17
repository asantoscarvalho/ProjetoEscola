using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Repository.inteface;

namespace ProjetoEscola.Repository.repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ProjetoEscolaContext _context;
        protected readonly DbSet<TEntity> dbSet;
        public Repository(ProjetoEscolaContext context)
        {
            this._context = context;
            this.dbSet = this._context.Set<TEntity>();
        }

        public void Dispose()
        {
          this._context.Dispose();        
        }
         public void Add<TEntity>(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Delete<TEntity>(TEntity entity)
        {
            _context.Remove(entity);
        }
        public void Update<TEntity>(TEntity entity)
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return ( await _context.SaveChangesAsync()) > 0;
             
        }
    }
}