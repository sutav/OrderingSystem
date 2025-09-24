using avantech.OrderingSystem.Data;
using avantech.OrderingSystem.Data.Data;

namespace avantech.OrderingSystem.Data
{
    public class GenericDbSet : IGenericDbSet
    {
        private bool disposedValue;
        private readonly ProductApiContext _context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public GenericDbSet(ProductApiContext context)
        {
            _context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (!repositories.ContainsKey(typeof(TEntity)))
            {
                repositories[typeof(TEntity)] = new GenericRepository<TEntity>(_context);
            }
            return (IRepository<TEntity>)repositories[typeof(TEntity)];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }            
        }
    }
    public interface IGenericDbSet : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
