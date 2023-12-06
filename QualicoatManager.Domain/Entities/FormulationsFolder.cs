namespace QualicoatManager.Domain.Entities
{
    public class FormulationsFolder : EntityWithName
    {
        public List<Formulation>? Formulations { get; set; }
    }
}
