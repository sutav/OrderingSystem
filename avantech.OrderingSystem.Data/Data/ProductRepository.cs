using avantech.OrderingSystem.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avantech.OrderingSystem.Data.Data
{
    public interface IProductRepository
    {
        IQueryable<Product> GetProducts(long? productCategoryId);
    }

    public class ProductRepository : IProductRepository
    {
        readonly ProductApiContext _context;
        private readonly ILogger<ProductApiContext> _logger;

        public ProductRepository(ProductApiContext context, ILogger<ProductApiContext> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IQueryable<Model.Product> GetProducts(long? productCategoryId)
        {         
            return _context.Products.AsNoTracking()
             .Where(d => (!productCategoryId.HasValue || d.ProductCategoryId == productCategoryId.Value));
        }

    }
}
