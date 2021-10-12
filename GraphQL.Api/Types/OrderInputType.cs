using GraphQL.Types;
using GraphQL.Models;
using GraphQL.Services;
using System;
using System.Linq.Expressions;

namespace GraphQlApi.GraphQl.Types
{
    public class OrderInputType : InputObjectGraphType
    {
        public OrderInputType()
        {
            Field<IntGraphType>("id","Order Id");
            Field<StringGraphType>("customerName", "Customer Name");
            Field<StringGraphType>("orderDate", "Order Date");
            Field<FloatGraphType>("totalAmount", "Total Order Price");
        }
    }
}
