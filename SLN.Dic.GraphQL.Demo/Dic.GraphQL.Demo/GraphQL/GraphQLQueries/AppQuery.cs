using Dic.GraphQL.Demo.Contracts;
using Dic.GraphQL.Demo.GraphQL.GraphQLTypes;
using GraphQL;
using GraphQL.Types;

namespace Dic.GraphQL.Demo.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository repository)
        {
            Field<ListGraphType<OwnerType>>(
               "owners",
               resolve: context => repository.GetAll()
           );

            Field<OwnerType>(
           "owner",
           arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
           resolve: context =>
           {
               Guid id;
               if (!Guid.TryParse(context.GetArgument<string>("ownerId"),out id))   
               {
                   context.Errors.Add(new ExecutionError("Valor incorrecto para guid"));
               }
               return repository.GetById(id);
           }
       );
            //Field<OwnerType>(
            //    "owner",
            //    arguments => new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
            //    resolve: context =>
            //    {
            //        var id = context.GetArgument<Guid>("ownerId");
            //        return repository.GetById(id);
            //    }
            //    );

        }
    }
}
