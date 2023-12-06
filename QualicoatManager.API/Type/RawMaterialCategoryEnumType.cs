using GraphQL.Types;

namespace QualicoatManager.API.Type
{
    public class RawMaterialCategoryEnumType : EnumerationGraphType<RawMaterialCategory>
    {
        public RawMaterialCategoryEnumType()
        {
            Name = "RawMaterialCategoryEnum";
            Description = "Enumeration for raw material categories";
        }
    }
}
