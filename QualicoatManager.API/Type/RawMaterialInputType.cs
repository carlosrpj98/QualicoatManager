using GraphQL.Types;

namespace QualicoatManager.API.Type
{
    public class RawMaterialInputType : InputObjectGraphType
    {
        public RawMaterialInputType()
        {
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
            Field<RawMaterialCategoryEnumType>("category");
        }
    }
}
