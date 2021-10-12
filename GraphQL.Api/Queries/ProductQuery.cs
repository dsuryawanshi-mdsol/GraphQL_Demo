using GraphQL;
using GraphQL.Types;
using GraphQlApi.GraphQl.Types;
using GraphQL.Interfaces;

namespace GraphQlApi.GraphQl.Queries
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProduct productService)
        {
            Field<ListGraphType<ProductType>>("products",
                resolve: context => { return productService.GetAllProducts(); });

            Field<ProductType>("product",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => { return productService.GetProductById(context.GetArgument<int>("id")); });

        }
    }
}
