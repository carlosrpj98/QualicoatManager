using GraphQL.Types;
using QualicoatManager.Domain.Entities;

namespace QualicoatManager.API.Type
{
    public class BaseUserType : ObjectGraphType<BaseUser>
    {
        public BaseUserType()
        {
            Field(u => u.Id);
            Field(u => u.Name);
            Field(u => u.Password);
            Field(u => u.UserRoles);
        }
    }
}
