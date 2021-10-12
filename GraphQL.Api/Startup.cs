using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Data;
using GraphQlApi.GraphQl.Mutations;
using GraphQlApi.GraphQl.Queries;
using GraphQlApi.GraphQl.Schemas;
using GraphQlApi.GraphQl.Types;
using GraphQL.Interfaces;
using GraphQL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQlApi
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Services
            services.AddTransient<IProduct, ProductService>();
            services.AddTransient<IOrder, OrderService>();

            //Types
            services.AddTransient<ProductType>();
            services.AddTransient<ProductInputType>();
            services.AddTransient<OrderType>();
            services.AddTransient<OrderInputType>();

            //Queries and Mutations
            services.AddTransient<ProductQuery>();
            services.AddTransient<OrderQuery>();

            services.AddTransient<RootQuery>();
            services.AddTransient<RootMutation>();

            services.AddTransient<ProductMutation>();
            services.AddTransient<OrderMutation>();

            //Schema's
            services.AddTransient<ISchema, RootSchema>();

            //GraphQl
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;

            }).AddSystemTextJson();

            services.AddDataServices(configuration);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ProductDbContext productDbContext, OrderDbContext orderDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            productDbContext.Database.EnsureCreated();
            orderDbContext.Database.EnsureCreated();

            app.UseGraphQLVoyager("/ui/voyager");
            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();
        }
    }
}
