using DAL.Entities;
using DTOs.ProductDTOS;


namespace BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductServiceResponse> GetProductsAsync(int position);
        Task<ProductServiceResponse> CreateProductsAsync(CreateProductDTO productDTO);
        Task<ProductServiceResponse> GetActiveProductsAsync(int position);

        Task<ProductServiceResponse> UpdateProductsAsync(Product product);
        Task<ProductServiceResponse> DeleteProductsAsync(Guid productId);


        Task<ProductServiceResponse> GetProductById(Guid ProductId);


        

    }
}
