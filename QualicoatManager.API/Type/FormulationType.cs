using GraphQL.Types;
using QualicoatManager.Domain.Entities;

namespace QualicoatManager.API.Type
{
    public class FormulationType : ObjectGraphType<Formulation>
    {
        public FormulationType()
        {
            Field(f => f.Id);
            Field(f => f.Name);
            Field(f => f.Description);
            Field(f => f.Date);
            Field(f => f.Items);
            Field(f => f.AssesmentsGroup);
            Field(f => f.TotalAmount);

        }
    }
}
