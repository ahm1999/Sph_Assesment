using DAL.Entities;
using DTOs.ClientDTOS;

namespace BLL.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClientServiceResponse> CreateClient(CreateCLientDTO createClientDTO);

        Task<ClientServiceResponse> GetALlClientsAsync(int position);

        Task<ClientServiceResponse> GetClientByCodeAsync(int Code);
        Task<ClientServiceResponse> GetJustClientByCodeAsync(int Code);

        Task<ClientServiceResponse> DeleteClientAsync(int code);


        Task<ClientServiceResponse> EditClientAsync(Client client);
  
    }
}
