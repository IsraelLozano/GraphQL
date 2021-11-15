using Dic.GraphQL.Demo.GraphQL.GraphQLQueries;
using GraphQL.Types;

namespace Dic.GraphQL.Demo.GraphQL.GraphQLSchema
{
    public class AppSchema:Schema
    {
        public AppSchema(IServiceProvider provider)
        : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
            Mutation = provider.GetRequiredService<AppMutation>();

        }

    }
}
