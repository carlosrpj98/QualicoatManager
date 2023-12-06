using GraphQL.Types;

namespace QualicoatManager.API.Type
{
    public class FormulationItemInputType : InputObjectGraphType
    {
        public FormulationItemInputType()
        {
            Field<ListGraphType<RawMaterialInputType>>("rawMaterial");
            Field<FloatGraphType>("amount");
        }
    }
}
