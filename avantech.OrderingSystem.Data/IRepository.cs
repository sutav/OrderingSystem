using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace avantech.OrderingSystem.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity? GetById(string id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void SaveChanges();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
