using GraphQL.Types;
using GraphQLTestApp.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApp.Schemas
{
    public class CustomerDTOSchema : ObjectGraphType<CustomerDTO>
    {
        public CustomerDTOSchema()
        {
            Name = "CustomerDTO";

            Field(_ => _.CId);
            Field(_ => _.CName);
            Field(_ => _.CPhone);
            Field(_ => _.CAddress);
        }
    }
}
