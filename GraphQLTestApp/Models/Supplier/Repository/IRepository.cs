using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApp.Models.Supplier.Repository
{
    interface IRepository
    {
        public IFlurlClient client { get; set; }
        public void AddSuppliers(IList<SupplierDTO> suppliers);
        public Task<IList<SupplierDTO>> GetSuppliers();
        public Task<SupplierDTO> GetSupplierById(int s_id);
    }

    public class SupplierRepository : IRepository
    {
        public IFlurlClient client { get; set; }

        public SupplierRepository(IFlurlClientFactory flurlFactory, IConfiguration configuration)
        {
            this.client = flurlFactory.Get(new Url(configuration.GetValue(typeof(String), "BASE_URL").ToString()));
        }

        public void AddSuppliers(IList<SupplierDTO> suppliers)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<SupplierDTO>> GetSuppliers()
        {
            return await client.Request("v1", "api", "suppliers").GetJsonAsync<IList<SupplierDTO>>();
        }

        public async Task<SupplierDTO> GetSupplierById(int s_id)
        {
            return await client.Request("v1", "api", "supplier").SetQueryParams(new { s_id = s_id }).GetJsonAsync<SupplierDTO>();
        }

    }
}
