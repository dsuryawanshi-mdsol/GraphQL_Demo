using GraphQL;
using GraphQL.Types;
using GraphQlApi.GraphQl.Types;
using GraphQL.Interfaces;
using GraphQL.Models;
using Microsoft.AspNetCore.Http;

namespace GraphQlApi.GraphQl.Mutations
{
    public class OrderMutation : ObjectGraphType
    {
        public OrderMutation(IOrder orderService,
            IProduct productService, 
            IHttpContextAccessor accessor)
        {
            // CreateOrder Mutation
            Field<OrderType>("createOrder",
                 arguments: new QueryArguments(new QueryArgument<OrderInputType> { Name = "order" }),
                 resolve: context => { return orderService.AddOrder(context.GetArgument<Order>("order")); });

            // CreateOrderWithProduct Mutation
            Field<OrderType>("createOrderWithProduct",
                 arguments: new QueryArguments(
                     new QueryArgument<OrderInputType> { Name = "order" },
                     new QueryArgument<ProductInputType> { Name = "product" }
                     ),
                 resolve: context => 
                 {
                     //var x = accessor.HttpContext.Request.Headers;

                     Order order = orderService.AddOrder(context.GetArgument<Order>("order"));

                     Product product = context.GetArgument<Product>("product");
                     product.OrderId = order.Id;

                     productService.AddProduct(product);

                     return order; 
                 });
        }
    }
}
