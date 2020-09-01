using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using GraphQLTestApp.Models.Supplier;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApp.Models.Product.Repository
{
    interface IRepository
    {
        public IFlurlClient client { get; set; }
        public void AddProducts(IList<ProductDTO> products);
        public Task<IList<ProductDTO>> GetProducts();
        public Task<ProductDTO> GetProductById(int p_id);
    }
    

    public class ProductRepository : IRepository
    {
        public IFlurlClient client { get; set; }

        public ProductRepository(IFlurlClientFactory flurlFactory, IConfiguration configuration)
        {
            this.client = flurlFactory.Get(new Url(configuration.GetValue(typeof(String), "BASE_URL").ToString()));
        }

        public void AddProducts(IList<ProductDTO> products)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ProductDTO>> GetProducts()
        {
            return await client.Request("v1", "api", "products").GetJsonAsync<IList<ProductDTO>>();
        }

        public async Task<ProductDTO> GetProductById(int p_id)
        {
            return await client.Request("v1", "api", "product").SetQueryParams(new { p_id = p_id }).GetJsonAsync<ProductDTO>();
        }
    }
}
