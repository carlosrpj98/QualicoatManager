namespace QualicoatManager.Domain.Entities
{
    public class EntityWithName : BaseEntity
    {
        public virtual string Name { get; set; } = string.Empty;
    }
}
