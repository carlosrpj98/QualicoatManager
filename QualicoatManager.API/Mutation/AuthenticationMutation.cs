using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Authentication;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;
using QualicoatManager.API.Services;

namespace QualicoatManager.API.Mutation
{
    public class AuthenticationMutation : ObjectGraphType
    {
        public AuthenticationMutation(IGenericRepository<BaseUser> userRepository, QualicoatManager.Service.AuthenticationService authenticationService)
        {
            Field<BaseUserType>("login")
                .Arguments( new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "username" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }
                )).ResolveAsync(async context =>
                 
                {
                    var username = context.GetArgument<string>("username");
                    var password = context.GetArgument<string>("password");

                    try
                    {
                        var user = await authenticationService.ValidateLoginAsync(username, password);
                        return user;
                    }
                    catch (Exception ex)
                    {
                        context.Errors.Add(new ExecutionError(ex.Message));
                        return null;
                    }
                }
            );

            Field<BooleanGraphType>("register")
                .Arguments(new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<UserRoleInputType>>> { Name = "roles" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "username" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "confirmPassword" }
                )).ResolveAsync(async context =>
                {
                    var roles = context.GetArgument<List<UserRole>>("roles");
                    var username = context.GetArgument<string>("username");
                    var password = context.GetArgument<string>("password");
                    var confirmPassword = context.GetArgument<string>("confirmPassword");

                    try
                    {
                        var success = await authenticationService.CreateUser(roles, username, password, confirmPassword);
                        return success;
                    }
                    catch (Exception ex)
                    {
                        context.Errors.Add(new ExecutionError(ex.Message));
                        return false;
                    }
                }
            );
        }
    }
}
