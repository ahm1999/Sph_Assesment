using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs.ClientProductDTOs;
using DTOs.Validators;

namespace BLL.Services
{
    public class ClientProductService : IClientProductService
    {
        private readonly IClientProductRepository _clientProductRepository;
        public ClientProductService(IClientProductRepository clientProductRepository)
        {
            _clientProductRepository = clientProductRepository;
        }
        public async Task<ClientProductServiceResponse> AddClientProductAsync(CreateClientProductDTO clientProductDTO)
        {
            CreateClientProductDTOValidator validator = new();

            if (!validator.Validate(clientProductDTO).IsValid) {

                return new ClientProductServiceResponse(false, "Validation error");

            }

            ClientProduct clientProduct = await _clientProductRepository.FindClientProductById(clientProductDTO.ClientCode, clientProductDTO.ProductId);

            if (clientProduct != null)
            {
                return new ClientProductServiceResponse(false, "Client Product already exists");
            }

            clientProduct = new() { 
                ProductId = clientProductDTO.ProductId,
                ClientCode = clientProductDTO.ClientCode,
                License = clientProductDTO.License,
                StartData = clientProductDTO.StartData,
                EndData = clientProductDTO.EndData
            
            };
            await _clientProductRepository.AddClientProductAsync(clientProduct);

            return new ClientProductServiceResponse(true, "ClientProduct added");
        }

        public async Task<ClientProductServiceResponse> DeleteClientProductAsync(int code, Guid ProductId)
        {
            var retclientProduct  = await _clientProductRepository.FindClientProductById(code,ProductId);

            if (retclientProduct == null)
            {
                return new ClientProductServiceResponse(false, "No CLient Product with that id exists");
            }
            await _clientProductRepository.DeleteClientProductAsync(retclientProduct);
            return new ClientProductServiceResponse(true, "Client Product deleted succesfully");


        }

        public async Task<ClientProductServiceResponse> GetClientProductByIdAsync(int code, Guid ProductId)
        {
            var retclientProduct = await _clientProductRepository.FindClientProductById(code, ProductId);

            if (retclientProduct == null)
            {
                return new ClientProductServiceResponse(false, "No CLient Product with that id exists");
            }
            var response = new ClientProductServiceResponse(true, "Client Product found succesfully");
            response.ClientProducts.Add(retclientProduct);
            return response;

        }

        public async Task<ClientProductServiceResponse> UpdateClientProductAsync(ClientProduct clientProduct)
        {
            ClientProductValidator validator = new();

            if (!validator.Validate(clientProduct).IsValid)
            {

                return new ClientProductServiceResponse(false, "Validation error");

            }
            await _clientProductRepository.UpdateClientProductAsync(clientProduct);
            return new ClientProductServiceResponse(true, "Client Product updated succesfully");
        }
    }

    public record ClientProductServiceResponse(bool success, string Messege) {

        public List<ClientProduct> ClientProducts { get; set; } = new List<ClientProduct>();
        public ClientProductServiceResponse(bool success,string Messege, List<ClientProduct> clientProducts):this(success,Messege)
        {
            this.ClientProducts = clientProducts;
        }

    }
}
