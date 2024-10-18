using BLL.Services.Interfaces;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using DTOs.ProductDTOS;
using DTOs.Validators;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductServiceResponse> CreateProductsAsync(CreateProductDTO productDTO)
        {

            CreateProductDTOValidator validator = new();

            if (!validator.Validate(productDTO).IsValid)
            {

                return new ProductServiceResponse(false, "Validation error");

            }
            Product product = new() { 
                ProductId = Guid.NewGuid(),
                Description = productDTO.Description,
                IsActive = productDTO.IsActive,
                Name = productDTO.Name
                
            };

            
            await _productRepository.AddProductAsync(product);

            var response = new ProductServiceResponse(true, "Product Added Succesfully");

            response.Products.Add(product);

            return response;

        }

        public async Task<ProductServiceResponse> DeleteProductsAsync(Guid productId)
        {
            Product retProduct = await _productRepository.GetProductById(productId);

            if (retProduct == null)
            {
                return new ProductServiceResponse(false, "no Product with that id exists");
            }

            await _productRepository.DeleteProductAsync(retProduct);
            return new ProductServiceResponse(true, "Product deleted Succesfully");
        }

        public async Task<ProductServiceResponse> GetActiveProductsAsync(int position)
        {
            List<Product> products = await _productRepository.GetAllActiveProductsAsync(position);
            int count = await _productRepository.GetActiveProductCountAsync();
            return new ProductServiceResponse(true, "Product retrieved Succesfully", products,count);
        }

        public async Task<ProductServiceResponse> GetProductById(Guid ProductId)
        {
            var product =  await _productRepository.GetProductById(ProductId);
            if (product == null)
            {
               return  new ProductServiceResponse(false, "no Product with that id exists");
            }
            var response = new ProductServiceResponse(true, "Product retrieved Succesfully");
            response.Products.Add(product);
            return response;
        }

        public async Task<ProductServiceResponse> GetProductsAsync(int position)
        {
            List<Product> products =  await _productRepository.GetAllProductsAsync(position);

            int Count = await _productRepository.GetProductCountAsync();
            return new ProductServiceResponse(true, "Product retrieved Succesfully", products,Count);
        }

        public async Task<ProductServiceResponse> UpdateProductsAsync(Product product)
        {
            ProductValidator validator = new();

            if (!validator.Validate(product).IsValid)
            {

                return new ProductServiceResponse(false, "Validation error");

            }
            await _productRepository.UpdateProductAsync(product);

            return new ProductServiceResponse(true, "Product retrieved Succesfully");

        }
    }

    public record ProductServiceResponse(bool Success, string messege) {
        public List<Product> Products { get; set; } = new List<Product>();
        public int ProductCount { get; set; } = 0;
        public ProductServiceResponse(bool Success, string messege,List<Product> products,int ProductCount):this (Success,messege)
        {
            this.Products = products;
            this.ProductCount = ProductCount;
        }
    }
}
