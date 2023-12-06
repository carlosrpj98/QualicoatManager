namespace QualicoatManager.Domain.Entities
{
    public interface IBaseUser
    { 
        public string Name { get; set; }
        public string Password { get; set; }
        //ICollection<UserRole> UserRoles { get; set; }
    }
}