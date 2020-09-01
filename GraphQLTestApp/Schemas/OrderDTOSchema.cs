using GraphQL.Types;
using GraphQLTestApp.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApp.Schemas
{
    public class OrderDTOSchema : ObjectGraphType<OrderDTO>
    {
        public OrderDTOSchema()
        {
            Name = "OrderDTO";

            Field(_ => _.Name);
            Field(_ => _.Address);
            Field(_ => _.Phone);
            Field(_ => _.ODate);
            Field(_ => _.OType);
            Field(_ => _.products, type: typeof(ProductDTOSchema));

        }
    }
}