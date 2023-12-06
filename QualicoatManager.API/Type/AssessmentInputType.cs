using GraphQL.Types;

namespace QualicoatManager.API.Type
{
    public class AssessmentInputType : InputObjectGraphType
    {
        public AssessmentInputType()
        {
            Field<StringGraphType>("name");
            Field<StringGraphType>("result");
            Field<StringGraphType>("expected");
            Field<BooleanGraphType>("success");
        }
    }
}
