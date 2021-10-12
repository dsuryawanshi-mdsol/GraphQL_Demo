using GraphQL.Types;

namespace GraphQlApi.GraphQl.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<ProductQuery>("productQuery", resolve: context => new { });
            Field<OrderQuery>("orderQuery", resolve: context => new { });
        }
    }
}
