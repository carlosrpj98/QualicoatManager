namespace QualicoatManager.Domain.Entities
{
    public class UserRole : EntityWithName
    {

        public int UserId { get; set; }
        public Roles Role { get; set; }
        public BaseUser User { get; set; } = new BaseUser();

        public UserRole()
        {
            Name = Role.ToString();
        }
    }


}

public enum Roles
{
    Admin,
    RegularUser,
    ReadOnlyUser
}