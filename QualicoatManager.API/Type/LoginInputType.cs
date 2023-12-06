using GraphQL.Types;

namespace QualicoatManager.API.Type
{
    public class LoginInputType : InputObjectGraphType
    {
        public LoginInputType()
        {
            Field<StringGraphType>("username");
            Field<StringGraphType>("password");
        }
    }
}
