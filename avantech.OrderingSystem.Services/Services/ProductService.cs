using avantech.OrderingSystem.Data.Data;
using avantech.OrderingSystem.Data.Model;
using avantech.OrderingSystem.Services.Contracts;
using avantech.OrderingSystem.Data;

namespace avantech.OrderingSystem.Services.Services
{
    public class ProductService: IProductService
    {
        readonly IProductRepository _repository;       
        public ProductService(
            IProductRepository repository          
            )
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
            catch (Exception ex) {
                throw ex;
            }

        }
    }
}
