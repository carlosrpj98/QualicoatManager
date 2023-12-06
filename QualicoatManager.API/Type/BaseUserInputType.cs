using GraphQL.Types;

namespace QualicoatManager.API.Type
{
    public class BaseUserInputType : InputObjectGraphType
    {
        public BaseUserInputType()
        {
            Field<StringGraphType>("Name");
            Field<StringGraphType>("Password");
            Field<ListGraphType<RoleEnumType>>("Roles");
        }
    }
}
