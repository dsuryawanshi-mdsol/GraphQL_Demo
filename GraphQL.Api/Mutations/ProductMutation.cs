using GraphQL;
using GraphQL.Types;
using GraphQlApi.GraphQl.Types;
using GraphQL.Interfaces;
using GraphQL.Models;

namespace GraphQlApi.GraphQl.Mutations
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct productService)
        {
            // CreateProduct Mutation
            Field<ProductType>("createProduct",
                 arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                 resolve: context => { return productService.AddProduct(context.GetArgument<Product>("product")); });

            // UpdateProduct Mutation
            Field<ProductType>("updateProduct",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" },
                           new QueryArgument<ProductInputType> { Name = "product" }),
                 resolve: context =>
                 {
                     int id = context.GetArgument<int>("id");
                     Product product = context.GetArgument<Product>("product");

                     return productService.UpdateProduct(id, product);
                 });

            // DeleteProduct Mutation
            Field<StringGraphType>("deleteProduct",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                 resolve: context =>
                 {
                     int id = context.GetArgument<int>("id");

                     productService.DeleteProduct(id);

                     return $"The product with productId {id} is deleted.";

                 });
        }
    }
}
