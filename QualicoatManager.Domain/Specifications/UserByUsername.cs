using QualicoatManager.Domain.Entities;

namespace QualicoatManager.Domain.Specifications
{
    public class UserByUsername : BaseSpecification<BaseUser>
    {
        public UserByUsername(string username) : base(x => x.Name == username)
        {
        }
    }
}
