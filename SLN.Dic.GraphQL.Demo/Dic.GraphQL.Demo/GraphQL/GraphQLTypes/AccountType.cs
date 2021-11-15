using Dic.GraphQL.Demo.Entities;
using GraphQL.Types;

namespace Dic.GraphQL.Demo.GraphQL.GraphQLTypes
{

    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the account object.");
            Field(x => x.Description).Description("Description property from the account object.");
            Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
            Field<AccountTypeEnumType>("Type", "Enumeracion para las cuentas del objeto");
        }
    }
}
