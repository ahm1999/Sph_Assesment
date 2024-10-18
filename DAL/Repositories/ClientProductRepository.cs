using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ClientProductRepository : IClientProductRepository
    {
        private readonly AppDbContext _context;
        public ClientProductRepository(AppDbContext context)
        {
            _context = context; 
        }
        public async Task<ClientProduct> AddClientProductAsync(ClientProduct ClientProduct)
        {
            await _context.ClientProducts.AddAsync(ClientProduct);
            await _context.SaveChangesAsync();
            return ClientProduct;
        }

        public async Task<ClientProduct> DeleteClientProductAsync(ClientProduct ClientProduct)
        {
            _context.ClientProducts.Remove(ClientProduct);
            await _context.SaveChangesAsync();
            return ClientProduct;
        }

        public async Task<ClientProduct> FindClientProductById(int ClientCode, Guid ProductId)
        {
            return await _context.ClientProducts.FirstOrDefaultAsync(cp => cp.ClientCode == ClientCode && cp.ProductId == ProductId);
        }

        public async Task<List<ClientProduct>> GetAllClientProductsForClientAsync(int ClientCode)
        {
            return await _context.ClientProducts.Where(cp => cp.ClientCode == ClientCode).ToListAsync();
        }

     
        public async Task UpdateClientProductAsync(ClientProduct ClientProduct)
        {
            var retClientProduct =  await FindClientProductById(ClientProduct.ClientCode, ClientProduct.ProductId);

            if (retClientProduct == null)
            {
                return;
            }
            retClientProduct.License = ClientProduct.License;
            retClientProduct.StartData = ClientProduct.StartData;
            retClientProduct.EndData = ClientProduct.EndData;

            await _context.SaveChangesAsync();

        }
    }
}
