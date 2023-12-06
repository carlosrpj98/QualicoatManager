using GraphQL.Types;
using QualicoatManager.Domain.Entities;

namespace QualicoatManager.API.Type
{
    public class AssessmentType : ObjectGraphType<Assessment>
    {
        public AssessmentType()
        {
            Field(a => a.Id);
            Field(a => a.Name);
            Field(a => a.Expected);
            Field(a => a.Result);
            Field(a => a.Success, nullable: true).Description("Success or not depending on the assessments results.");
        }
    }
}
