using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;
using QualicoatManager.Domain.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace QualicoatManager.API.Mutation
{
    public class AssessmentsGroupMutation : ObjectGraphType
    {
        public AssessmentsGroupMutation(IGenericRepository<AssessmentsGroup> repository)
        {
            Field<AssessmentsGroupType>("CreateAssessmentsGroup")
                .Arguments(new QueryArguments(new QueryArgument<AssessmentsGroupInputType> { Name = "assessmentsGroup" }))
                .ResolveAsync(async context =>
                {
                    var assessmentsGroup = context.GetArgument<AssessmentsGroup>("assessmentsGroup");
                    await repository.CreateItemAsync(assessmentsGroup);
                    return assessmentsGroup;
                });

            Field<AssessmentsGroupType>("UpdateAssessmentsGroup")
                      .Arguments(new QueryArguments(new QueryArgument<AssessmentsGroupInputType> { Name = "assessmentsGroup" },
                      new QueryArgument<IntGraphType> { Name = "assessmentsGroupId" }))
                      .ResolveAsync(async context =>
                      {
                          var assessmentsGroupId = context.GetArgument<int>("assessmentsGroupId");
                          var assessmentsGroup = context.GetArgument<AssessmentsGroup>("assessmentsGroup");
                          await repository.UpdateItemAsync(assessmentsGroup, assessmentsGroupId);
                          return assessmentsGroup;
                      });

            Field<StringGraphType>("DeleteAssessmentsGroup")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "assessmentsGroupId" }))
                .ResolveAsync(async context =>
                {
                    var assessmentsGroupId = context.GetArgument<int>("assessmentsGroupId");
                    await repository.DeleteItemAsync(assessmentsGroupId);
                    return $"The assessmentsGroup against the id {assessmentsGroupId} has been deleted successfully.";
                });



        }

    }
}


