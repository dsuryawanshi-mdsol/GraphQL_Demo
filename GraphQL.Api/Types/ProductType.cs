using GraphQL.Types;
using GraphQL.Models;

namespace GraphQlApi.GraphQl.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Name = "Product";
            Field(p => p.Id).Description("Product Id"); ;
            Field(p => p.Name).Description("Product Name");
            Field(p => p.Price).Description("Product Price");
            Field(p => p.OrderId).Description("Order Id"); ;
        }
    }
}
