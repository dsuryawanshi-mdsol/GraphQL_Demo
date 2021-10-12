using GraphQL.Types;

namespace GraphQlApi.GraphQl.Types
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<FloatGraphType>("price");
            Field<IntGraphType>("orderId");
        }
    }
}
