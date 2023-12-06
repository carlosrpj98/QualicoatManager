namespace QualicoatManager.Domain.Entities
{
    public class FormulationItem : EntityWithName
    {
        public string Name => RawMaterial.Name;
        public RawMaterial RawMaterial { get; set; }
        public float Amount { get; set; }
    }
}
