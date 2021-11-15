using Dic.GraphQL.Demo.Contracts;
using Dic.GraphQL.Demo.Entities;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace Dic.GraphQL.Demo.GraphQL.GraphQLTypes
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(IAccountRepository repository, IDataLoaderContextAccessor dataLoader )
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the owner object.");
            Field(x => x.Name).Description("Name property from the owner object.");
            Field(x => x.Address).Description("Address property from the owner object.");
            Field<ListGraphType<AccountType>>(
                "accounts",
                resolve: context =>
                {
                    var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<Guid, Account>("GetAccountsByOwnerIds", repository.GetAccountsByOwnerIds);
                    return loader.LoadAsync(context.Source.Id);
                }
                );
            //Field<ListGraphType<AccountType>>(
            //  "accounts",
            //  resolve: context => repository.GetAllAccountsPerOwner(context.Source.Id)
            //  );

        }
    }
}
