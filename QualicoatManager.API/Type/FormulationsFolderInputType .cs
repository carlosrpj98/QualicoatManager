using GraphQL.Types;

namespace QualicoatManager.API.Type
{
    public class FormulationsFolderInputType : InputObjectGraphType
    {
        public FormulationsFolderInputType()
        {
            Field<ListGraphType<FormulationInputType>>("formulations");
        }
    }
}
