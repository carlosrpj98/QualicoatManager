namespace QualicoatManager.Domain.Entities
{
    public class BaseUser : EntityWithName, IBaseUser
    {
        public string Password { get; set; } = string.Empty;
       public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}

