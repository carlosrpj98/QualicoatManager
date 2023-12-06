using GraphQL.Types;

namespace QualicoatManager.API.Type
{
    public class FormulationInputType : InputObjectGraphType
    {
        public FormulationInputType()
        {
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
            Field<ListGraphType<FormulationItemInputType>>("items");
            Field<AssessmentsGroupInputType>("assessmentsGroup");
        }
    }
}
