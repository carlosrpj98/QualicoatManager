using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;
using QualicoatManager.Domain.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace QualicoatManager.API.Mutation
{
    public class UserRoleMutation : ObjectGraphType
    {
        public UserRoleMutation(IGenericRepository<UserRole> repository)
        {
            Field<UserRoleType>("CreateUserRole")
                .Arguments(new QueryArguments(new QueryArgument<UserRoleInputType> { Name = "userRole" }))
                .ResolveAsync(async context =>
                {
                    var userRole = context.GetArgument<UserRole>("userRole");
                    await repository.CreateItemAsync(userRole);
                    return userRole;
                });

            Field<UserRoleType>("UpdateUserRole")
                 .Arguments(new QueryArguments(new QueryArgument<UserRoleInputType> { Name = "userRole" },
                 new QueryArgument<IntGraphType> { Name = "userRoleId" }))
                 .ResolveAsync(async context =>
                 {
                     var userRoleId = context.GetArgument<int>("userRoleId");
                     var userRole = context.GetArgument<UserRole>("userRole");
                     await repository.UpdateItemAsync(userRole, userRoleId);
                     return userRole;
                 });

            Field<StringGraphType>("DeleteUserRole")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "userRoleId" }))
                .ResolveAsync(async context =>
                {
                    var userRoleId = context.GetArgument<int>("userRoleId");
                    await repository.DeleteItemAsync(userRoleId);
                    return $"The userRole against the id {userRoleId} has been deleted successfully.";
                });



        }

    }
}


