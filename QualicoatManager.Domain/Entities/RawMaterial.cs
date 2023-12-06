namespace QualicoatManager.Domain.Entities
{
    public class RawMaterial : EntityWithName
    {
        public RawMaterialCategory Category { get; set; }
        public string? Description { get; set; } 

    }
}

public enum RawMaterialCategory
{
    Resin, 
    CuringAgent,
    Filler,
    Additive,
    PostAddable,
    Pigment,
    Other
}
