using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Data
{
    public static class Startup
    {
        public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("productsConnection")));
            services.AddDbContext<OrderDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("ordersConnection")));            
        }
    }
}
