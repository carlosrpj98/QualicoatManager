using GraphQL.Types;

namespace QualicoatManager.API.Type
{
    public class RoleEnumType : EnumerationGraphType<Roles>
    {
        public RoleEnumType()
        {
            Name = "RoleEnum";
            Description = "Enumeration for user roles";
        }
    }
}
