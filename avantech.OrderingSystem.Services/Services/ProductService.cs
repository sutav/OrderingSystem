using avantech.OrderingSystem.Data.Data;
using avantech.OrderingSystem.Data.Model;
using avantech.OrderingSystem.Services.Contracts;
using avantech.OrderingSystem.Data;

namespace avantech.OrderingSystem.Services.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Product> GetProducts(long? productCategoryId)
        {
            try
            {
                var result = _repository.GetProducts(productCategoryId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product InsertProduct(Product product)
        {
            try
            {
                return _repository.InsertProduct(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product UpdateProduct(int productId, Product product)
        {
            try
            {
                return _repository.UpdateProduct(productId, product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                return _repository.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
