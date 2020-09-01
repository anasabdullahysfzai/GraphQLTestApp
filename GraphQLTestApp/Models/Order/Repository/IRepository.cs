using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApp.Models.Order.Repository
{
    interface IRepository
    {
        public IFlurlClient client { get; set; }
        public void AddOrder(OrderDTO customers);
        public Task<IList<OrderDTO>> GetOrdersBySupplierId(int s_id);
        public Task<IList<OrderDTO>> GetOrdersByCustomerId(int c_id);
    }

    public class OrderRepository : IRepository
    {
        public IFlurlClient client { get; set; }

        public OrderRepository(IFlurlClientFactory flurlFactory, IConfiguration configuration)
        {
            this.client = flurlFactory.Get(new Url(configuration.GetValue(typeof(String), "BASE_URL").ToString()));
        }

        public async void AddOrder(OrderDTO customers)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<OrderDTO>> GetOrdersBySupplierId(int s_id)
        {
            return await client.Request("v1", "api", "ordersbysupplierid").SetQueryParams(new { s_id = s_id }).GetJsonAsync<IList<OrderDTO>>();
        }

        public async Task<IList<OrderDTO>> GetOrdersByCustomerId(int c_id)
        {
            return await client.Request("v1", "api", "ordersbysupplierid").SetQueryParams(new { c_id = c_id }).GetJsonAsync<IList<OrderDTO>>();
        }
    }
}
