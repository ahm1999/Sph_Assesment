using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs.ClientDTOS;
using DTOs.Validators;

namespace BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<ClientServiceResponse> CreateClient(CreateCLientDTO createClientDTO)
        {
             CreateClientDTOValidator validator = new();

            if (!validator.Validate(createClientDTO).IsValid)
            {

                return new ClientServiceResponse(false, "Validation error");

            }

            Client newClient = new()
            {
                Name = createClientDTO.Name,
                CLientClass = createClientDTO.CLientClass,
                State = createClientDTO.State

            };

            await _clientRepository.AddClientAsync(newClient);
            return new ClientServiceResponse(true, "Client Created Succesfully");
        }

        public async Task<ClientServiceResponse> DeleteClientAsync(int code)
        {
            Client client =  await _clientRepository.GetJustClientByCodeAsync(code);

            if (client == null)
            {
                return new ClientServiceResponse(false, "No client with that id exists");
            }

            await _clientRepository.DeleteClientAsync(client);

            return new ClientServiceResponse(true, "Client Deleted succesfully");

        }

        public async Task<ClientServiceResponse> EditClientAsync(Client client)
        {
            ClientValidator validator = new();

            if (!validator.Validate(client).IsValid)
            {
                return new ClientServiceResponse(false, "Validation error");
            }

            await _clientRepository.UpdateClientAsync(client);
            return new ClientServiceResponse(true, "client Updated Succesfully");
        }

        public async Task<ClientServiceResponse> GetALlClientsAsync(int position)
        {
            List<Client> clients = await _clientRepository.GetAllClientsAsync(position);
            int count = await _clientRepository.GetClientCount();
            return new ClientServiceResponse(true, "Clients retrieved", clients,count);
        }

        public async Task<ClientServiceResponse> GetClientByCodeAsync(int Code)
        {
            Client client = await _clientRepository.GetClientByIdAsync(Code);

            if (client ==null)
            {
                return new ClientServiceResponse(false, "No client with that id exists");

            }

            var response = new ClientServiceResponse(true, "client retrieved ");

            response.Clients.Add(client);

            return response;

        }

        public async Task<ClientServiceResponse> GetJustClientByCodeAsync(int Code)
        {
            Client client = await _clientRepository.GetJustClientByCodeAsync(Code);
            if (client == null)
            {
                return new ClientServiceResponse(false, "No client with that id exists");

            }

            var response = new ClientServiceResponse(true, "client retrieved ");

            response.Clients.Add(client);

            return response;

        }
    }

        public record ClientServiceResponse(bool Success, string Messege) {
        public List<Client> Clients { get; set; } = new List<Client>();
        public int ClientCount { get; set; }
        public ClientServiceResponse(bool Success, string Messege,List<Client> clients ,int ClientCount) : this (Success,Messege)
            {
                this.Clients = clients;
                this.ClientCount = ClientCount;
            }

        }

}
