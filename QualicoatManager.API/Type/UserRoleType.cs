using GraphQL.Types;
using QualicoatManager.Domain.Entities;

namespace QualicoatManager.API.Type
{
    public class UserRoleType : ObjectGraphType<UserRole>
    {
        public UserRoleType()
        {
            Field(u => u.Id);
            Field(u => u.UserId);
            Field(u => u.User);
            Field(u => u.Role);
        }
    }
}
