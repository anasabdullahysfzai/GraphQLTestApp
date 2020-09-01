using GraphQL.Types;
using GraphQLTestApp.Models.Customer.Repository;
using GraphQLTestApp.Models.Order.Repository;
using GraphQLTestApp.Models.Product.Repository;
using GraphQLTestApp.Models.Supplier.Repository;
using GraphQLTestApp.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace GraphQLTestApp.Queries
{
    public class CustomerQuery : ObjectGraphType
    {
        public CustomerQuery(CustomerRepository _repo)
        {
            Field<ListGraphType<CustomerDTOSchema>>(
                name: "customers",
                resolve: context =>
                {
                    return _repo.GetCustomers();
                }
               );

            Field<CustomerDTOSchema>(
                name: "customer",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "c_id" }),
                resolve: context =>
                {
                    int c_id = context.GetArgument<int>("c_id");
                    return _repo.GetCustomerById(c_id);
                }
                );
        }
    }

    public class OrderQuery : ObjectGraphType
    {
        public OrderQuery(OrderRepository _repo)
        {
                Field<ListGraphType<OrderDTOSchema>>(
                    name : "customerorders",
                    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "c_id" }),
                    resolve: context =>
                    {
                        int c_id = context.GetArgument<int>("c_id");
                        return _repo.GetOrdersByCustomerId(c_id);
                    }
                );

                Field<ListGraphType<OrderDTOSchema>>(
                    name: "supplierorders",
                    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "s_id" }),
                    resolve: context =>
                    {
                        int s_id = context.GetArgument<int>("s_id");
                        return _repo.GetOrdersBySupplierId(s_id);
                    }
                );
        }
    }

    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(ProductRepository _repo)
        {
                Field<ListGraphType<ProductDTOSchema>>(
                    name: "products",
                    resolve: context => 
                    {
                        return _repo.GetProducts();
                    }
                );

                Field<ProductDTOSchema>(
                    name: "product",
                    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "p_id" }),
                    resolve: context => 
                    {
                        int p_id = context.GetArgument<int>("p_id");
                        return _repo.GetProductById(p_id);
                    }
                
                );
        }
    }

    public class SupplierQuery : ObjectGraphType
    {
        public SupplierQuery(SupplierRepository _repo)
        {
                Field<ListGraphType<SupplierDTOSchema>>(
                    name: "suppliers",
                    resolve: context =>
                    {
                        return _repo.GetSuppliers();
                    }
                );

                Field<SupplierDTOSchema>(
                    name: "supplier",
                    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "s_id" }),
                    resolve: context =>
                    {
                        int s_id = context.GetArgument<int>("s_id");
                        return _repo.GetSupplierById(s_id);
                    }
                );
        }
    }
}
