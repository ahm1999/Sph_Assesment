using DAL.Entities;
namespace DAL.Interfaces
{

    public interface IClientRepository
    {
        public  Task<Client> AddClientAsync(Client client);

        public Task<List<Client>> GetAllClientsAsync(int position);

        public Task<Client> DeleteClientAsync(Client client);

        public Task<Client> GetClientByIdAsync(int id);  

        public Task UpdateClientAsync(Client client);

        public Task<Client> GetJustClientByCodeAsync(int code);

        public Task<int> GetClientCount();

    }
}
