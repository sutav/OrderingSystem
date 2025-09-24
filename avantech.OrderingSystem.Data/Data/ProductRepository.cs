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
            //var p1 = new Product() { ProductId = 1, Description = "Product 1 Desc", Name = "Product 1", Price = (decimal?)11.50, ProductCategoryId = 1 };
            //var p2 = new Product() { ProductId = 1, Description = "Product 2 Desc", Name = "Product 2", Price = (decimal?)15.50, ProductCategoryId = 1 };
            //var p3 = new Product() { ProductId = 1, Description = "Product 3 Desc", Name = "Product 3", Price = (decimal?)21.50, ProductCategoryId = 1 };
            //List<Product> products = new List<Product>();
            //products.Add(p1);
            //products.Add(p2);
            //products.Add(p3);
            //return products.AsQueryable();
            return _context.Products.AsNoTracking()
             .Where(d => (!productCategoryId.HasValue || d.ProductCategoryId == productCategoryId.Value));
        }

    }
}
