using GraphQL.Types;
using QualicoatManager.Domain.Entities;

namespace QualicoatManager.API.Type
{
    public class FormulationsFolderType : ObjectGraphType<FormulationsFolder>
    {
        public FormulationsFolderType()
        {
            Field(f => f.Id);
            Field(f => f.Name);
            Field(f => f.Formulations);
        }
    }
}
