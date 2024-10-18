using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IClientProductRepository
    {
        public Task<ClientProduct> AddClientProductAsync(ClientProduct ClientProduct);

        public Task<List<ClientProduct>> GetAllClientProductsForClientAsync(int ClientCode);

        public Task<ClientProduct> FindClientProductById(int ClientCode,Guid ProductId);

        public Task<ClientProduct> DeleteClientProductAsync(ClientProduct ClientProduct);

        public Task UpdateClientProductAsync(ClientProduct ClientProduct);

    }
}
