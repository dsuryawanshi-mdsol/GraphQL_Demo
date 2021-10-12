using GraphQL;
using GraphQL.Types;
using GraphQlApi.GraphQl.Types;
using GraphQL.Interfaces;

namespace GraphQlApi.GraphQl.Queries
{
    public class OrderQuery : ObjectGraphType
    {
        public OrderQuery(IOrder orderService)
        {
            Field<ListGraphType<OrderType>>("orders",
                resolve: context => { return orderService.GetAllOrders(); });

            Field<OrderType>("order",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => { return orderService.GetOrderById(context.GetArgument<int>("id")); });
        }
    }
}
