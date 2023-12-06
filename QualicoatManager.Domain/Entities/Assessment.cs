namespace QualicoatManager.Domain.Entities
{
    public class Assessment : EntityWithName
    {
        public string? Expected { get; set; }
        public string? Result { get; set; }
        public bool? Success { get; set; }
    }
}
