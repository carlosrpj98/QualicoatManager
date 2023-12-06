using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;

namespace QualicoatManager.API.Query
{
    public class BaseUserQuery : ObjectGraphType
    {
        public BaseUserQuery(IGenericRepository<BaseUser> repository)
        {
            Field<ListGraphType<BaseUserType>>("Users").ResolveAsync(async context =>
            {
                return await repository.GetAllAsync();
            });

            Field<BaseUserType>("User").Arguments(new QueryArgument<IntGraphType> { Name = "userId" }).ResolveAsync(async context =>
            {
                return await repository.GetByIdAsync(context.GetArgument<int>("userId"));
            });
        }
    }
}
