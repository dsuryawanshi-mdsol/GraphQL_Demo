using GraphQL.Types;
using GraphQlApi.GraphQl.Mutations;
using GraphQlApi.GraphQl.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQlApi.GraphQl.Schemas
{
    public class RootSchema : Schema
    {
        public RootSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
            Mutation = serviceProvider.GetRequiredService<RootMutation>();
        }
    }
}
