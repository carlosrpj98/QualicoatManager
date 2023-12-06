using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Services;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;
using QualicoatManager.Domain.Repositories;
using QualicoatManager.Service;
using System.Reflection.Metadata.Ecma335;

namespace QualicoatManager.API.Mutation
{
    public class BaseUserMutation : ObjectGraphType
    {
        public BaseUserMutation(IGenericRepository<BaseUser> repository)
        {
            Field<BaseUserType>("CreateUser")
                .Arguments(new QueryArguments(new QueryArgument<BaseUserInputType> { Name = "user" }))
                .ResolveAsync(async context =>
                {
                    var baseUser = context.GetArgument<BaseUser>("user");
                    await repository.CreateItemAsync(context.GetArgument<BaseUser>("user"));
                    return baseUser;
                });

            Field<BaseUserType>("UpdateBaseUser")
                 .Arguments(new QueryArguments(new QueryArgument<BaseUserInputType> { Name = "baseUser" },
                 new QueryArgument<IntGraphType> { Name = "baseUserId" }))
                 .ResolveAsync(async context =>
                 {
                     var baseUserId = context.GetArgument<int>("baseUserId");
                     var baseUser = context.GetArgument<BaseUser>("baseUser");
                     await repository.UpdateItemAsync(baseUser, baseUserId);
                     return baseUser;
                 });

            Field<StringGraphType>("DeleteUser")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "userId" }))
                .ResolveAsync(async context =>
                {
                    var userId = context.GetArgument<int>("userId");
                    await repository.DeleteItemAsync(userId);
                    return $"The user against the id {userId} has been deleted successfully.";
                });
        }

    }
}


