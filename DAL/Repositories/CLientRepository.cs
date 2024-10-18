using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;


namespace DAL.Repositories
{

    
    class CLientRepository : IClientRepository
    {

        private readonly AppDbContext _context;
        public CLientRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<Client> AddClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> DeleteClientAsync(Client client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<List<Client>> GetAllClientsAsync(int position)
        {
            if (position<0)
            {
                position = 0;
            }
            return await _context.Clients
                                 .OrderBy(c => c.Code)
                                 .Skip(position * 10)
                                 .Take(10)
                                 .ToListAsync();
            }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context.Clients
                                 .Where(c => c.Code == id)
                                 .Include(c => c.ClientProducts)
                                 .ThenInclude(cp => cp.Product)
                                 .FirstOrDefaultAsync();

           
        }

        public Task<int> GetClientCount()
        {
            return _context.Clients.CountAsync();
        }

        public async Task<Client> GetJustClientByCodeAsync(int code)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task UpdateClientAsync(Client client)
        {

            var retclient = await _context.Clients.FindAsync(client.Code);

            if (retclient == null)
            {
                return ;
            }

            retclient.Name = client.Name;
            retclient.CLientClass = client.CLientClass;
            retclient.State = client.State;

            await _context.SaveChangesAsync();

        }
    }

    

}



//public async Task<List<Client>> GetAllClientsAsync(Expression<Func<Client, bool>> clientPredicate)
//{
//    return await _context.Clients.Where(clientPredicate).ToListAsync();
//}
