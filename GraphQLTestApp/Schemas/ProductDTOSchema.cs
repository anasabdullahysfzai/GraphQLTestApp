using GraphQL.Types;
using GraphQLTestApp.Models.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApp.Schemas
{
    public class ProductDTOSchema : ObjectGraphType<ProductDTO>
    {
        public ProductDTOSchema()
        {
            Name = "ProductDTO";

            Field(_ => _.PId);
            Field(_ => _.PCode);
            Field(_ => _.PName);
            Field(_ => _.PPrice);
            Field(_ => _.PStock);
        }
    }
}
