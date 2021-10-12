using GraphQL.Types;
using GraphQL.Interfaces;
using GraphQL.Models;

namespace GraphQlApi.GraphQl.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(IProduct productService)
        {
            Field(p => p.Id).Description("Order Id");
            Field(p => p.CustomerName).Description("Customer Name");
            Field(p => p.OrderDate).Description("Order Date");
            Field(p => p.TotalAmount).Description("Total Amount");

            Field<ListGraphType<ProductType>>("products",
                  resolve: context => { return productService.GetProductByOderId(context.Source.Id); });
        }
    }
}
