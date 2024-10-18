
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IProductRepository
    {

        public Task<Product> AddProductAsync(Product product);
        public Task<List<Product>> GetAllProductsAsync(int position);
        public Task<List<Product>> GetAllActiveProductsAsync(int Positoin);
        public Task<Product> DeleteProductAsync(Product product);

        public Task<Product> GetProductById(Guid Id);

        public Task UpdateProductAsync(Product product);

        public Task<int> GetProductCountAsync();
        public Task<int> GetActiveProductCountAsync();



    }
}
