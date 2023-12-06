using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;

namespace QualicoatManager.API.Query
{
    public class AssessmentsGroupQuery : ObjectGraphType
    {
        public AssessmentsGroupQuery(IGenericRepository<AssessmentsGroup> repository)
        {
            Field<ListGraphType<AssessmentsGroupType>>("AssessmentsGroup").ResolveAsync(async context =>
            {
                return await repository.GetAllAsync();
            });

            Field<AssessmentsGroupType>("AssessmentsGroups").Arguments(new QueryArgument<IntGraphType> { Name = "assessmentsGroupId" }).ResolveAsync(async context =>
            {
                return await repository.GetByIdAsync(context.GetArgument<int>("assessmentsGroupId"));
            });
        }
    }
}
