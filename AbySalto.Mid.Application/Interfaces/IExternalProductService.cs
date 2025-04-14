using AbySalto.Mid.Application.DTO;

namespace AbySalto.Mid.Application.Interfaces
{
    public interface IExternalProductService
    {
        public Task<List<Product>?> GetAllProductsAsync();
        public Task<Product?> GetProductByIdAsync(int id);
    }
}
