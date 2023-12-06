using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;

namespace QualicoatManager.API.Query
{
    public class UserRoleQuery : ObjectGraphType
    {
        public UserRoleQuery(IGenericRepository<UserRole> repository)
        {
            Field<ListGraphType<UserRoleType>>("UserRoles").Resolve(context =>
            {
                return repository.GetAllAsync();
            });

            Field<UserRoleType>("UserRole").Arguments(new QueryArgument<IntGraphType> { Name = "userRoleId" }).Resolve(context =>
            {
                return repository.GetByIdAsync(context.GetArgument<int>("userRoleId"));
            });
        }
    }
}
