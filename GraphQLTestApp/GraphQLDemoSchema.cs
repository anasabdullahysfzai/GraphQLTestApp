using GraphQL;
using GraphQL.Types;
using GraphQLTestApp.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApp
{
    public class GraphQLDemoSchema : Schema , ISchema
    {
        public GraphQLDemoSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<CustomerQuery>();
            Query = dependencyResolver.Resolve<OrderQuery>();
            Query = dependencyResolver.Resolve<ProductQuery>();
            Query = dependencyResolver.Resolve<SupplierQuery>();
        }
    }
}
