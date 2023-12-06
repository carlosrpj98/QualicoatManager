using GraphQL.Types;

namespace QualicoatManager.API.Type
{
    public class UserRoleInputType : InputObjectGraphType
    {
        public UserRoleInputType()
        {
            Field<IntGraphType>("userId");     
            Field<RoleEnumType>("role");
            Field<BaseUserInputType>("user");
        }
    }
}
