using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL 
{
    public static class DALservices
    {

        public static void registerDALdependincies(this IServiceCollection services, IConfiguration Configuration) {

            services.AddDbContext<AppDbContext>(options =>{
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            });

            services.AddScoped<IClientRepository, CLientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IClientProductRepository,ClientProductRepository>();
        }
    }
}
