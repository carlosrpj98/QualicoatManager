using GraphQL.Types;

namespace QualicoatManager.API.Type
{
    public class AssessmentsGroupInputType : InputObjectGraphType
    {
        public AssessmentsGroupInputType()
        {
            Field<StringGraphType>("name");
            Field<ListGraphType<AssessmentInputType>>("assessments");
        }
    }
}
