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

        Product InsertProduct(Product product);
        Product UpdateProduct(int productId, Product product);
        bool DeleteProduct(int productId);
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

        public Product InsertProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product UpdateProduct(int productId, Product product)
        {
            var existing = _context.Products.Find(productId);
            if (existing == null) return null;

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.ProductCategoryId = product.ProductCategoryId;

            _context.SaveChanges();
            return existing;
        }

        public bool DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null) return false;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }
    }
}
