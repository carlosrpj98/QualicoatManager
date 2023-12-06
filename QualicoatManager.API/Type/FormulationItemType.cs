using GraphQL.Types;
using QualicoatManager.Domain.Entities;

namespace QualicoatManager.API.Type
{
    public class FormulationItemType : ObjectGraphType<FormulationItem>
    {
        public FormulationItemType()
        {
            Field(f => f.Id);
            Field(f  => f.Name);
            Field(f  => f.RawMaterial);
            Field(f  => f.Amount);
        }

    }
}
