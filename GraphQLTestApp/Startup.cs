using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http.Configuration;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQLTestApp.Models.Customer.Repository;
using GraphQLTestApp.Models.Order.Repository;
using GraphQLTestApp.Models.Product.Repository;
using GraphQLTestApp.Models.Supplier.Repository;
using GraphQLTestApp.Schemas;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GraphQL.Types;

namespace GraphQLTestApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add FLUrl Dependency

            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();


            services.AddScoped<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
            //Add GraphQL Writer and Executer
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<IDocumentWriter, DocumentWriter>();
            //Add Repositories
            services.AddScoped<CustomerRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<SupplierRepository>();
            //Add Queries
            services.AddScoped<GraphQLTestApp.Queries.CustomerQuery>();
            services.AddScoped <GraphQLTestApp.Queries.OrderQuery>();
            services.AddScoped <GraphQLTestApp.Queries.ProductQuery>();
            services.AddScoped<GraphQLTestApp.Queries.SupplierQuery>();
            //Add Schemas
            services.AddScoped<CustomerDTOSchema>();
            services.AddScoped<OrderDTOSchema>();
            services.AddScoped<ProductDTOSchema>();
            services.AddScoped<SupplierDTOSchema>();
            //Add GraphQL Schema
            services.AddScoped<ISchema, GraphQLDemoSchema>();

            services.AddHttpContextAccessor();

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //Use GraphiQL Middleware

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions( ));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(opt =>
            {
                opt.MapControllers();
            });
        }
    }
}
