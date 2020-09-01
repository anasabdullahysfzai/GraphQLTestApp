using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApp.Models.Customer.Repository
{
    interface IRepository
    {
        public IFlurlClient client { get; set; }
        public void AddCustomers(IList<CustomerDTO> customers);
        public Task<IList<CustomerDTO>> GetCustomers();
        public Task<CustomerDTO> GetCustomerById(int c_id);
    }

    public class CustomerRepository : IRepository
    {
        public IFlurlClient client { get; set; }

        public CustomerRepository(IFlurlClientFactory flurlFactory, IConfiguration configuration)
        {
            this.client = flurlFactory.Get(new Url(configuration.GetValue(typeof(String), "BASE_URL").ToString()));
        }

        public async void AddCustomers(IList<CustomerDTO> customers)
        {
            
        }

        public async Task<IList<CustomerDTO>> GetCustomers()
        {
            return await client.Request("v1", "api", "customers").GetJsonAsync <IList<CustomerDTO>>();
        }

        public async Task<CustomerDTO> GetCustomerById(int c_id)
        {
            return await client.Request("v1", "api", "customer").SetQueryParams(new { c_id = c_id }).GetJsonAsync<CustomerDTO>();
        }

  
    }
}
