using GraphQL.Types;
using GraphQLTestApp.Models.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApp.Schemas
{
    public class SupplierDTOSchema : ObjectGraphType<SupplierDTO>
    {
        public SupplierDTOSchema()
        {
            Name = "SupplierDTO";

            Field(_ => _.SId);
            Field(_ => _.SName);
            Field(_ => _.SAddress);
            Field(_ => _.SPhone);
            Field(_ => _.SIban);
        }
    }
}
