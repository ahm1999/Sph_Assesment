using DAL.Entities;
using DAL.Repositories;
using DTOs.ClientProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IClientProductService
    {
        Task<ClientProductServiceResponse> AddClientProductAsync(CreateClientProductDTO clientProductDTO);
        Task<ClientProductServiceResponse> UpdateClientProductAsync(ClientProduct clientProduct);
        Task<ClientProductServiceResponse> DeleteClientProductAsync(int code ,Guid ProductId);
        Task<ClientProductServiceResponse> GetClientProductByIdAsync(int code ,Guid ProductId);


    }
}
