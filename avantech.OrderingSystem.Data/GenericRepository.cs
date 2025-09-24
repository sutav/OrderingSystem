using Microsoft.EntityFrameworkCore;
using avantech.OrderingSystem.Data.Data;
using System.Linq.Expressions;

namespace avantech.OrderingSystem.Data
{
    public class GenericRepository<TEntity>(ProductApiContext context) : IRepository<TEntity> where TEntity : class
    {
        private readonly ProductApiContext _context = context;
        private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public TEntity? GetById(string id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity).Entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
    }
}
