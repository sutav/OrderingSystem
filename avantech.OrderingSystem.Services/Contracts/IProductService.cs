using avantech.OrderingSystem.Data.Model;
using System.Linq;

namespace avantech.OrderingSystem.Services.Contracts
{
    public interface IProductService
    {
        IQueryable<Product> GetProducts(long? productCategoryId);

        Product InsertProduct(Product product);
        Product UpdateProduct(int productId, Product product);
        bool DeleteProduct(int productId);
    }
}
