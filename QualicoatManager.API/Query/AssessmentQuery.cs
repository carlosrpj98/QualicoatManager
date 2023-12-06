using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;

namespace QualicoatManager.API.Query
{
    public class AssessmentQuery : ObjectGraphType
    {
        public AssessmentQuery(IGenericRepository<Assessment> repository)
        {
            Field<ListGraphType<AssessmentType>>("Assessments").ResolveAsync( async context =>
            {
                return await repository.GetAllAsync();
            });

            Field<AssessmentType>("Assessment").Arguments(new QueryArgument<IntGraphType> { Name = "assessmentId" }).ResolveAsync( async context =>
            {
                return await repository.GetByIdAsync(context.GetArgument<int>("assessmentId"));
            });
        }
    }
}
