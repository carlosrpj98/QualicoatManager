using GraphQL.Types;

namespace QualicoatManager.API.Type
{
    public class RegisterInputType : InputObjectGraphType
    {

        public RegisterInputType()
        {
            Field<StringGraphType>("username");
            Field<StringGraphType>("password");
            Field<StringGraphType>("confirmPassword");
            Field<ListGraphType<RoleEnumType>>("assessments");
        }
    }
}
