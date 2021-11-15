using Dic.GraphQL.Demo.Entities;
using GraphQL.Types;

namespace Dic.GraphQL.Demo.GraphQL.GraphQLTypes
{
    public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type";
            Description = "Enumeration for the account type object.";
        }
    }
}
