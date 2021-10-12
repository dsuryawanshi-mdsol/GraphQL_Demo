using GraphQL.Types;

namespace GraphQlApi.GraphQl.Mutations
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<ProductMutation>("productMutation", resolve: context => new { });
            Field<OrderMutation>("orderMutation", resolve: context => new { });
        }
    }
}
