using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class BLLServices
    {
        public static void registerBLLdependincies(this IServiceCollection services, IConfiguration Configuration) {

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IClientProductService, ClientProductService>();
        }
    }
}
