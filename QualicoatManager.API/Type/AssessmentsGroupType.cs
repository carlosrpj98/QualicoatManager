using GraphQL.Types;
using QualicoatManager.Domain.Entities;

namespace QualicoatManager.API.Type
{
    public class AssessmentsGroupType : ObjectGraphType<AssessmentsGroup>
    {
        public AssessmentsGroupType()
        {
            Field(a => a.Id);
            Field(a => a.Assesments);
        }
    }
}
